using Blog.Application.Helpers;
using Blog.Application.Interfaces.Services;
using Blog.Application.Mediators;
using Blog.Application.Services.Account.Register;
using Blog.Application.Services.Users.Queries.GetById;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;

namespace Blog.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));

        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;
            configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        });

        services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidator).Assembly);

        services.AddCommandHandlers(typeof(RegisterUserHandler));
        services.AddQueryHandler(typeof(GetUserByIdQueryHandler));

        services.AddScoped<IMediator, Mediator>();
        services.AddScoped<CustomTokenHandler>();

        return services;
    }

    private static IServiceCollection AddCommandHandlers(this IServiceCollection services, Type assemblyType)
    {
        if (assemblyType == null)
            throw new ArgumentNullException(nameof(assemblyType));

        var assembly = assemblyType.Assembly;
        var scanType = typeof(ICommandHandler<>);

        RegisterScanTypeWithImplementations(services, assembly, scanType);

        return services;
    }

    private static IServiceCollection AddQueryHandler(this IServiceCollection services, Type assemblyType)
    {
        if (assemblyType == null)
            throw new ArgumentNullException(nameof(assemblyType));

        var assembly = assemblyType.Assembly;
        var scanType = typeof(IQueryHandler<,>);

        services.RegisterScanTypeWithImplementations(assembly, scanType);

        return services;
    }

    private static void RegisterScanTypeWithImplementations(
        this IServiceCollection services,
        Assembly assembly,
        Type typeScan)
    {
        var CommandHandlers = ScanTypes(assembly, typeScan);

        foreach (var handler in CommandHandlers)
        {
            var abstraction = handler.GetTypeInfo()
                .ImplementedInterfaces
                .First(type => type.IsGenericType && type.GetGenericTypeDefinition() == typeScan);

            services.AddScoped(abstraction, handler);
        }
    }
    private static IEnumerable<Type> ScanTypes(Assembly assembly, Type typeToScanFor)
    {
        return assembly.GetTypes()
            .Where(type => type is
            {
                IsClass: true,
                IsAbstract: false
            } && type.GetInterfaces()
                  .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeToScanFor));
    }
}
