using Volo.Abp.Application.Services;
using PatientSystem.Localization;

namespace PatientSystem.Services;

/* Inherit your application services from this class. */
public abstract class PatientSystemAppService : ApplicationService
{
    protected PatientSystemAppService()
    {
        LocalizationResource = typeof(PatientSystemResource);
    }
}