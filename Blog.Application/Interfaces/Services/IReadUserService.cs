using Blog.Application.Models;
using Blog.Application.Services.Users.GetAllUser;
using Blog.Domain.Common;
using Blog.Domain.Entity.Read;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface IReadUserService
{
    Task<Result<GetAllUsersByPageResponse, Error>> GetAllUserByPage(
        GetEntityModelByPageRequest request, 
        CancellationToken token);
    Task<Result<UserDto, Error>> GetUserById(Guid id, CancellationToken token);
}