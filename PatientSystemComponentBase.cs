using PatientSystem.Localization;
using Volo.Abp.AspNetCore.Components;

namespace PatientSystem;

public abstract class PatientSystemComponentBase : AbpComponentBase
{
    protected PatientSystemComponentBase()
    {
        LocalizationResource = typeof(PatientSystemResource);
    }
}
