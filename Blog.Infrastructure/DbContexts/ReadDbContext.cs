using Blog.Domain.Entity.Read;
using Blog.Infrastructure.Configurations.Write;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DbContexts;

public class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

    public DbSet<UserDto> Users => Set<UserDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly,
            type => type.FullName.Contains(".Read"));

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
}
