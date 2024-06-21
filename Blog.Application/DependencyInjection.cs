using Blog.Application.Helpers;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models.Validators;
using Blog.Application.Services.Articles.Read;
using Blog.Application.Services.Users.Create;
using Blog.Application.Services.Users.ReadUserService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Blog.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWriteUserService, WriteUserService>();
        services.AddScoped<IReadUserService, ReadUserService>();
        services.AddScoped<IReadArticleService, ReadArticleService>();

        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;
            configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        });

        services.AddValidatorsFromAssembly(typeof(CreateUserRequestValidator).Assembly);

        return services;
    }
}
