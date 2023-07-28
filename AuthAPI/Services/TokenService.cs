using AuthAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Services;

public class TokenService
{
    public void GenerateToken(User user)
    {
        // Reinvindicações
        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("ID", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes("iu29dfkamcla9w89cvhjadj21qw9zi20slALASKJSID29409SAIFVASF92387F98WEcdeflyingmoralityoftheblackgodsabbathhahaha"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(4),
            claims: claims,
            signingCredentials: signingCredentials
            );
    }
}
