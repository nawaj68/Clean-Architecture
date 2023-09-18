using System.Reflection;
using CorrelationId;
using TaskManagement.Backend;
using TaskManagement.Backend.Filters;
using TaskManagement.Infrastructure.Persistence.Interceptors;
using TaskManagement.IoC.Configuration;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddAuthentication();
builder.Configuration.AddEnvironmentVariables().AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddJsonFile("Settings.json");
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddAuthorization();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .MapCore()
    .AddInfrastructureServices(builder.Configuration);

builder.Services.AddWebUIServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen(c =>
{
   // c.OperationFilter<AuthResponsesOperationFilter>();
    c.UseInlineDefinitionsForEnums();
});
var app = builder.Build();
app.UseStaticFiles();
app.UseCorrelationId();
app.UseSwaggerDocumentation(app.Environment);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    // Initialise and seed database

    using var scope = app.Services.CreateScope();
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initializer.InitialiseAsync();
    await initializer.SeedAsync();
}

app.UseHttpsRedirection();
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();