using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Users.Queries.GetById;

public record GetByIdQuery(Guid Id) : IQuery;
