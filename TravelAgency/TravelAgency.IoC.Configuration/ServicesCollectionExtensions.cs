using CorrelationId.DependencyInjection;
using CorrelationId.HttpClient;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.Core;
using TravelAgency.Core.Behavior;
using TravelAgency.Infrastructure.Services;
using TravelAgency.Models;
using TravelAgency.Repository.Concrete;
using TravelAgency.Repository.Interface;
using TravelAgency.Service.Model;
using TravelAgency.Shared.Common.Interface;

namespace TravelAgency.IoC.Configuration;

public static class ServicesCollectionExtensions
{

    public static IServiceCollection MapCore(this IServiceCollection services)
    {
        services.AddDefaultCorrelationId();
        //services.AddControllers(config =>
        //{
        //    config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
        //    {
        //        Duration = 30
        //    });
        //}).AddJsonOptions(options =>
        //{
        //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        //    options.JsonSerializerOptions.WriteIndented = true;
        //}); ;
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
            cfg.CreateMap<Tourist, TouristVM>().ReverseMap();
        });
        services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

        services.AddScoped(typeof(ICommonService<,,>), typeof(CommonService<,,>));
        services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            // cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<>));
        });
        return services;
    }
}
