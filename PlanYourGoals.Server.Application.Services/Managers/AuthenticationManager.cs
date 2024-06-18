using System.IdentityModel.Tokens.Jwt;
using PlanYourGoals.Server.Application.Services.Managers.Interfaces;

namespace PlanYourGoals.Server.Application.Services.Managers;

public class AuthenticationManager : IAuthenticationManager
{
    public int GetUserId(string bearer)
    {
        var token = bearer.Split(" ")[1];

        var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(token);

        var claimValue = tokenHandler.Claims.First(claim =>
            claim.Type == "Id").Value;

        var id = int.Parse(claimValue);

        return id;
    }

    public string GetUserEmail(string bearer)
    {
        var token = bearer.Split(" ")[1];

        var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(token);

        var email = tokenHandler.Claims.First(claim =>
            claim.Type == JwtRegisteredClaimNames.Sub).Value;

        return email;
    }
}