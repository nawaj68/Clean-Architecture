using System.Reflection;
using System.Text.Json.Serialization;

using CorrelationId.DependencyInjection;
using CorrelationId.HttpClient;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Core;
using TaskManagement.Core.Behaviour;
using M=TaskManagement.Models;
using TaskManagement.Repositories.Concrete;
using TaskManagement.Repositories.Interfaces;
using S=TaskManagement.Service.Models;
using TaskManagement.Infrastructure.Services;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Contracts;

namespace TaskManagement.IoC.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection MapCore(this IServiceCollection services)
    {
        services.AddDefaultCorrelationId();
        services.AddControllers(config =>
        {
            config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
            {
                Duration = 30
            });
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.WriteIndented = true;
        });;
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        services.AddApiVersioning(o =>
        {
            o.ReportApiVersions = true;
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.AssumeDefaultVersionWhenUnspecified = true;
            

        });
        
        services.AddHttpClient(string.Empty)
            .AddCorrelationIdForwarding();
        services.AddHttpContextAccessor();
        services.AddAutoMapper(cfg =>
        {
            cfg.CreateMap<M.ProductItem, S.ProductItem>().ReverseMap();
            cfg.CreateMap<M.Product, S.Product>().ReverseMap();
            cfg.CreateMap<M.Employee, S.Employee>().ReverseMap();
        });
        services.AddScoped(typeof(IRepository<,>), typeof(TaskManagementRepositoryBase<,>));

        services.AddScoped(typeof(ICommonService<,,>), typeof(CommonService<,,>));
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