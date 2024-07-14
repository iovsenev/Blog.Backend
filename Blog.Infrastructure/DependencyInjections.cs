using Blog.Application.Interfaces.DbAccess;
using Blog.Infrastructure.DbContexts;
using Blog.Infrastructure.Queries;
using Blog.Infrastructure.Repositories;
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

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IArticleQueries, ArticleQueries>();
        services.AddSingleton<SqlConnectionFactory>();

        return services;
    }
}
