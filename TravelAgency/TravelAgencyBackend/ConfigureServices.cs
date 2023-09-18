using TravelAgency.Infrastructure.Persistence;
using TravelAgency.Shared.Common.Interface;
using TravelAgencyBackend.Services;

namespace TravelAgencyBackend;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<TravelAgenceContext>();



        return services;
    }
}
