using Blog.Domain.Entity.Read;
using Blog.Application.Interfaces;
using Blog.Infrastructure.Configurations.Write;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DbContexts;

public class ReadDbContext : DbContext, IReadDbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

    public DbSet<UserDto> Users { get; set; }
    public DbSet<ArticleDto> Articles { get; set; }
    public DbSet<CommentDto> Comments { get; set; }
    public DbSet<TagDto> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly,
            type => type.FullName.Contains(".Read"));

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
}
