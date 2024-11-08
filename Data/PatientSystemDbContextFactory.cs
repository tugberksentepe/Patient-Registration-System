using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PatientSystem.Data;

public class PatientSystemDbContextFactory : IDesignTimeDbContextFactory<PatientSystemDbContext>
{
    public PatientSystemDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<PatientSystemDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new PatientSystemDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}