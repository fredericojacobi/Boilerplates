using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Extensions;

public static class JwtSecurityTokenHandlerExtensions
{
    public static string GenerateToken(this JwtSecurityTokenHandler tokenHandler, string jwtSecret, Guid userId)
    {
        var key = Encoding.ASCII.GetBytes(jwtSecret);
        var symmetricSecurityKey = new SymmetricSecurityKey(key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", userId.ToString())
                }
            ),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}