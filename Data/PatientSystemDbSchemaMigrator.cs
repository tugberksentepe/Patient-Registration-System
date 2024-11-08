using Volo.Abp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PatientSystem.Data;

public class PatientSystemDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public PatientSystemDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        
        /* We intentionally resolving the PatientSystemDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PatientSystemDbContext>()
            .Database
            .MigrateAsync();

    }
}
