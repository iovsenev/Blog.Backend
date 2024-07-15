using Blog.Application.EntityExtensions;
using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Users.Queries.GetByPage;
public class GetUsersByPageQueryHandler : IQueryHandler<GetUsersByPageQuery, GetAllUsersByPageResponse>
{
    private readonly IReadDbContext _context;

    public GetUsersByPageQueryHandler(IReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllUsersByPageResponse, Error>> HandleAsync(GetUsersByPageQuery query, CancellationToken token)
    {
        var users = _context.Users
            .Include(u => u.Articles)
            .Where(u => u.Articles.Count > 0);

        var count = users.Count();

        var result = await users
            .Skip((query.PageIndex - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(u => u.ToShortViewModel())
            .ToListAsync();

        return new GetAllUsersByPageResponse(result, count);
    }
}
