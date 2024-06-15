using Blog.Application.Interfaces;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Users.GetAllUser;
public class GetAllUsersByPage : IUserService<GetEntityModelByPageRequest,GetAllUsersByPageResponse>
{
    private readonly IReadDbContext _context;

    public GetAllUsersByPage(IReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllUsersByPageResponse, Error>> Handle(GetEntityModelByPageRequest request, CancellationToken token)
    {
        var users = _context.Users;

        var count = users.Count();

        var result = await users
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(u => u.ToShortViewModel())
            .ToListAsync();
            
        var response = new GetAllUsersByPageResponse(result, count);
    }
}
