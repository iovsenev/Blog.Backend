using Blog.Application.Helpers;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models;
using Blog.Application.Services.Users.Create;
using Blog.Application.Services.Users.Create.Validators;
using Blog.Application.Services.Users.GetAllUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Blog.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWriteUserService, WriteUserService>();
        services.AddScoped<IReadUserService, GetAllUsersByPageService>();

        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;
            configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        });

        services.AddValidatorsFromAssembly(typeof(CreateUserRequestValidator).Assembly);

        return services;
    }
}
