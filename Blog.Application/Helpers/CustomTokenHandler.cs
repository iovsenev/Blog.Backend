using Blog.Domain.Entity.Write;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Application.Helpers;
public class CustomTokenHandler
{
    private readonly JwtOptions _options;

    public CustomTokenHandler(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string CreateToken(UserEntity user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)
            }),
            Expires = DateTime.UtcNow.AddHours(_options.Expires),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(jwtToken);
    }
}
