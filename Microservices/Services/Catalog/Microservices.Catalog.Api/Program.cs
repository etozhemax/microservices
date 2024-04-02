using HealthChecks.UI.Client;
using Microservices.Catalog.Infrastructure.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMediatR((config) =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddHealthChecks()
    .AddMongoDb(builder.Configuration["CatalogDatabase:ConnectionString"], "Catalog Mongo Db Health Check", Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Catalog.Api", Version = "v1" });
});

builder.Services.AddControllers();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1");
    });
}

app.UseRouting();
app.UseAuthentication();
app.UseStaticFiles();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Run();
