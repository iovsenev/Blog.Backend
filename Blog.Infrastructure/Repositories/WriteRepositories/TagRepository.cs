using Blog.Application.Interfaces.DbAccess;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories.WriteRepositories;
public class TagRepository : ITagRepository
{
    private readonly WriteDbContext _context;

    public TagRepository(WriteDbContext context)
    {
        _context = context;
    }

    public async Task<Result<TagEntity, Error>> GetByTagNameAsync(string tagName, CancellationToken ct)
    {
        var tagResult = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName, ct);

        return tagResult is null ? ErrorFactory.General.NotFound($"Entity with {tagName} not found.") : tagResult;
    }
}
