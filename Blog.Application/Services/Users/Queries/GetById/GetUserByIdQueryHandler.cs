using Blog.Application.EntityExtensions;
using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Users.Queries.GetById;
public class GetUserByIdQueryHandler : IQueryHandler<GetByIdQuery, GetByIdResponse>
{
    private readonly IReadDbContext _context;

    public GetUserByIdQueryHandler(IReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetByIdResponse, Error>> HandleAsync(GetByIdQuery query, CancellationToken token)
    {
        if (query.Id.Equals(Guid.Empty))
            return ErrorFactory.General.NotValid($"This id: {query.Id} is not valid");

        var entity = await _context.Users
            .Include(u => u.Articles)
            .Include(u => u.Comments)
            .FirstOrDefaultAsync(u => u.Id == query.Id, token);

        if (entity is null)
            return ErrorFactory.General.NotFound($"Entity with id: {query.Id} not found.");

        return new GetByIdResponse( entity.ToPreviewViewModel());
    }
}
