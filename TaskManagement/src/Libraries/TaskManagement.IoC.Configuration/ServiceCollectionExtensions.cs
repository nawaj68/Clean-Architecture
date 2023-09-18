using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Core;
using TaskManagement.Core.Behaviour;
using TaskManagement.Infrastructure.Files.Maps;
using TaskManagement.Repositories.Concrete;
using TaskManagement.Repositories.Interfaces;

namespace TaskManagement.IoC.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection MapCore(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
            {
                Duration = 30
            });
        });
        services.AddHttpContextAccessor();
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<TaskManagement.Service.Models.Mapping>();
        });
        services.AddTransient<IUserRepository, UsersRepository>();
        services.AddTransient<ITouristRepository, TouristRepository>();
        services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
           // cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<>));
        });
        return services;
    }
}