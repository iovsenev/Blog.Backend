using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Application.Services.Account.Login;
public class LoginUserHandler : ICommandHandler<LoginUserCommand>
{
    private readonly IUserRepository _repository;
    private string _secretKey;

    public LoginUserHandler(IUserRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
    }

    public async Task<Result<string, Error>> HandleAsync(LoginUserCommand command, CancellationToken token)
    {
        var userResult = await _repository.GetByEmailAsync(command.Email, token);

        if (userResult.IsFailure)
            return userResult.Error;

        var user = userResult.Value;

        if (!BCrypt.Net.BCrypt.EnhancedVerify(command.Password, user.PasswordHash))
            return ErrorFactory.General.InValid("Password is not valid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(jwtToken);
    }
}
