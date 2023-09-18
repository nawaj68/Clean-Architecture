using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Infrastructure.Persistence.Interceptors;
using TravelAgency.Infrastructure.Persistence;
using TravelAgency.Shared.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            services.AddDbContext<TravelAgenceContext>(options =>
                options.UseInMemoryDatabase("TaskManagentDb"));
        else if (configuration.GetValue<bool>("UseSqLite"))
            services.AddDbContext<TravelAgenceContext>(options =>
                options.UseSqlite("Data Source=LocalDatabase.db"));
        else
            services.AddDbContext<TravelAgenceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(TravelAgenceContext).Assembly.FullName)));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<TravelAgenceContext>());
        services.AddTransient<DbContext>(provider => provider.GetRequiredService<TravelAgenceContext>());

        // services.AddScoped<ApplicationDbContextInitializer>();
        return services;
    }
    
}
