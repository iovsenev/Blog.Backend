using Blog.Domain.Entity.Write;
using Blog.Infrastructure.Configurations.Write;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DbContexts;
public class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

    public DbSet<UserEntity> Users => Set<UserEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly, 
            type => type.FullName.Contains(".Write"));

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
