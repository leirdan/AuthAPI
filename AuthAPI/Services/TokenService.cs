using AuthAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Services;

public class TokenService
{
    private IConfiguration _config;

    public TokenService(IConfiguration configuration){
        _config = configuration;
    }

    public string GenerateToken(User user)
    {
        // Reinvindicações
        Claim[] claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("ID", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config["SecurityKey"]));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(4),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
