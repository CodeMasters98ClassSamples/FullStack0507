using FullStack0507.MyInfrastructure.Persistence.Contexts;
using FullStack0507.MyWebApi.Intefaces;
using FullStack0507.MyWebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FullStack0507.MyInfrastructure;

public static class ConfigureLayer
{
    /// <summary>
    /// Applies the pending EF Core migrations, so the schema is always in sync with the model.
    /// Usage (in the startup project, after builder.Build()):
    /// <code>app.Services.ApplyMigrations();</code>
    /// </summary>
    public static async Task ApplyMigrationsAsync(this IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
    {
        await using AsyncServiceScope scope = serviceProvider.CreateAsyncScope();
        AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if ((await dbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await dbContext.Database.MigrateAsync(cancellationToken);
        }
    }

    public static void ApplyMigrations(this IServiceProvider serviceProvider)
        => serviceProvider.ApplyMigrationsAsync().GetAwaiter().GetResult();

    public static IServiceCollection AddMyInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

        //bool develop = true;
        //if (develop)
        //{
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseInMemoryDatabase("AppDbContextInMemory"));
        //}
        //else
        //{
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseSqlServer(connectionString));
        //}

        services.AddScoped<IProductService, ProductService>();

        //services.AddHealthChecks()
        //.AddCheck("Sample", () => HealthCheckResult.Healthy("A healthy result."))
        //.AddDbContextCheck<AppDbContext>("Database");

        return services;
    }
}
