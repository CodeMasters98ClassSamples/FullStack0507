using FullStack0507.MyInfrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FullStack0507.MyInfrastructure.Persistence;

/// <summary>
/// Design-time (dotnet-ef / Add-Migration / Update-Database) factory.
/// Reads the connection string from the startup project's appsettings so the
/// migrations are generated exactly against the same database provider.
/// </summary>
public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private const string ConnectionStringName = "AppDbContext";

    public AppDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddJsonFile("appsettings.stage.json", optional: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        string? connectionString = configuration.GetConnectionString(ConnectionStringName);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            // Only used to create the model (e.g. "Add-Migration"); Update-Database requires a real one.
            connectionString = "Data Source=.;Database=ProductDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        }

        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(EnsureTrustedCertificate(connectionString))
            .Options;

        return new AppDbContext(options);
    }

    /// <summary>
    /// The appsettings files use Encrypt=True while a local SQL Server instance usually
    /// presents a self-signed certificate ("certificate chain was issued by an authority
    /// that is not trusted"). Design-time tooling must therefore always trust the server certificate.
    /// </summary>
    private static string EnsureTrustedCertificate(string connectionString)
    {
        if (connectionString.Contains("TrustServerCertificate", StringComparison.OrdinalIgnoreCase))
            return connectionString;

        return connectionString.TrimEnd(';') + ";TrustServerCertificate=True";
    }
}
