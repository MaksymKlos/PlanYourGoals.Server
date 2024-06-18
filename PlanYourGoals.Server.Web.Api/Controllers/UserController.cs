using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;
using PlanYourGoals.Server.Application.Services.Services.Interfaces;
using PlanYourGoals.Server.Common.Core.Models;
using PlanYourGoals.Server.Web.Api.Models.DTOs.Project;
using PlanYourGoals.Server.Web.Api.Models.DTOs.User;

namespace PlanYourGoals.Server.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(
        IUserService userService,
        IAuthenticationManager authenticationManager,
        IIdentityManager identityManager,
        IMapper mapper
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            var bearer = HttpContext.Request.Headers["Authorization"];
            var userEmail = authenticationManager.GetUserEmail(bearer!);

            var user = await userService.GetByEmailAsync(userEmail);

            return Ok(mapper.Map<UserDTO>(user));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            var updatedUser = await userService.UpdateAsync(user);

            return Ok(mapper.Map<UserDTO>(updatedUser));
        }
    }
}