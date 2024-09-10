using Blog.Application.Interfaces.DbAccess;
using Blog.Infrastructure.DbContexts;
using Blog.Infrastructure.Repositories.WriteRepositories;
using FluentAssertions;

namespace Blog.Test;
public class WriteUserRepositoryTests
{
    private readonly WriteDbContext _context = CreateDbContext.CreateWriteDbContext();
    [Fact]
    public async Task GetAllUsers_success()
    {
        IUserRepository repo = new UserRepository(_context);

        var result = await repo.GetAllUsersAsync(new CancellationToken());

        result.IsSuccess.Should().BeTrue();
        result.Value.ToList().Count.Should().Be(1);
    }
}
