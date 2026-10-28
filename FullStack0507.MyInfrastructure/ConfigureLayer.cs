using FullStack0507.MyInfrastructure.Persistence.Contexts;
using FullStack0507.MyWebApi.Intefaces;
using FullStack0507.MyWebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FullStack0507.MyInfrastructure;

public static class ConfigureLayer
{
    public static IServiceCollection AddMyInfrastructure(this IServiceCollection services,string connectionString)
    {
        bool develop = true;
        if (develop)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("AppDbContextInMemory"));
        }
        else
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        services.AddScoped<IProductService, ProductService>();

        services.AddHealthChecks()
        .AddCheck("Sample", () => HealthCheckResult.Healthy("A healthy result."))
        .AddDbContextCheck<AppDbContext>("Database");

        return services;
    }
}
