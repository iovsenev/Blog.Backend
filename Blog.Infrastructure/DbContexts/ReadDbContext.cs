using Blog.Domain.Entity.Read;
using Blog.Infrastructure.Configurations.Write;
using Microsoft.EntityFrameworkCore;
using Blog.Application.Interfaces.DbAccess;

namespace Blog.Infrastructure.DbContexts;

public class ReadDbContext : DbContext, IReadDbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

    public DbSet<UserReadModel> Users { get; set; }
    public DbSet<ArticleReadModel> Articles { get; set; }
    public DbSet<CommentReadEntity> Comments { get; set; }
    public DbSet<TagReadModel> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly,
            type => type.FullName == null ? false : type.FullName.Contains(".Read"));

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
}
