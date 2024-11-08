using PatientSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PatientSystem.Permissions;

public class PatientSystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PatientSystemPermissions.GroupName);
        
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PatientSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
        
        var patientsPermission = 
            myGroup.AddPermission(PatientSystemPermissions.Patients.Default,
                L("Permission:Patient"));
        patientsPermission.AddChild(PatientSystemPermissions.Patients.Create,
            L("Permission:Patient.Create"));
        patientsPermission.AddChild(PatientSystemPermissions.Patients.Edit,
            L("Permission:Patient.Edit"));
        patientsPermission.AddChild(PatientSystemPermissions.Patients.Delete,
            L("Permission:Patient.Delete"));
    }
    

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PatientSystemResource>(name);
    }
}
