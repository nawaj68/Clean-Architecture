using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskManagement.Infrastructure.Persistence;

public class BloggingContextFactory : IDesignTimeDbContextFactory<TaskManagementContext>
{
    public TaskManagementContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<TaskManagementContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new TaskManagementContext(optionsBuilder.Options);
    }
}