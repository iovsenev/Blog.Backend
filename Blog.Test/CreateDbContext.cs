using BCrypt.Net;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Test;
internal static class CreateDbContext
{
    public static WriteDbContext CreateWriteDbContext()
    {
        var options = new DbContextOptionsBuilder<WriteDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new WriteDbContext(options);
        var pashash = BCrypt.Net.BCrypt.EnhancedHashPassword("password");
        context.Database.EnsureCreated();
        context.Users.Add(
            UserEntity.Create("admin@admin.admin", pashash, "admin", RoleEntity.Admin).Value);

        context.SaveChanges();
        return context;
    }

    public static void DisposeContext(DbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
