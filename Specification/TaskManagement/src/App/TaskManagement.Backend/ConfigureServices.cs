using TaskManagement.Backend.Services;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Backend;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<TaskManagementContext>();



        return services;
    }
}