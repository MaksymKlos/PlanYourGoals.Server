using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using PlanYourGoals.Server.Application.Services.Models;
using PlanYourGoals.Server.Common.Core.Models;
using PlanYourGoals.Server.Web.Api.Models.Response;
using PlanYourGoals.Server.Web.Api.Options;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;
using PlanYourGoals.Server.Web.Api.Models.DTOs.User;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(
        IIdentityManager identityManager,
        IUserService userService,
        IOptions<JwtOptions> options,
        IMapper mapper
        ) : ControllerBase
    {
        private readonly JwtOptions jwtOptions = options.Value;

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDTO request)
        {
            if (ModelState.IsValid)
            {
                var emailExist = await identityManager.FindByEmailAsync(request.Email);

                if (emailExist != null)
                {
                    return GenerateResponse(false, "", "Email already exists.");
                }

                await identityManager.RegisterIdentityAsync(mapper.Map<NewIdentityUser>(request));

                var user = await userService.CreateAsync(mapper.Map<User>(request));
                var userDTO = mapper.Map<UserDTO>(user);

                return GenerateResponse(true, GenerateJwtToken(userDTO));
            }

            return GenerateResponse(false, "", "Invalid request payload");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO request)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await identityManager.FindByEmailAsync(request.Email);
                if (existingUser == null)
                {
                    return GenerateResponse(false, "", "User does not exist.");
                }

                var isPasswordValid = await identityManager.CheckPasswordAsync(existingUser, request.Password);
                if (isPasswordValid)
                {
                    var user = await userService.GetByEmailAsync(request.Email);
                    var userDTO = mapper.Map<UserDTO>(user);
                    var token = GenerateJwtToken(userDTO);

                    return GenerateResponse(true, token);
                }

                return GenerateResponse(false, "", "Invalid password.");
            }

            return GenerateResponse(false, "", "Invalid request payload.");
        }

        private IActionResult GenerateResponse(bool result, string token = "", string error = "")
        {
            if (result)
            {
                return Ok(new AuthResponse
                {
                    Result = true,
                    Token = token
                });
            }

            return BadRequest(new AuthResponse
            {
                Result = false,
                Error = error
            });
        }

        private string GenerateJwtToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(jwtOptions.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
