using Blog.Application.Interfaces.DbAccess;
using Blog.Infrastructure.DbConfigurations;
using Blog.Infrastructure.DbContexts;
using Blog.Infrastructure.Repositories.ReadRepositories;
using Blog.Infrastructure.Repositories.WriteRepositories;
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

        services.AddDbContext<IReadDbContext, ReadDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("DatabaseAccess"));
        });

        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleReadRepository, ArticleReadRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddSingleton<SqlConnectionFactory>();
        services.AddScoped<InitialData>();
        return services;
    }
}
