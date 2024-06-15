using Blog.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure;
public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WriteDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("DatabaseAccess"));
        });
        services.AddDbContext<ReadDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("DatabaseAccess"));
        });

        return services;
    }
}
