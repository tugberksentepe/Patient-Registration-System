using PatientSystem.Permissions;
using PatientSystem.Entities.Patients;
using PatientSystem.Permissions;
using PatientSystem.Services.Dtos.Patients;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PatientSystem.Services.Patients;

public class PatientAppService:
    CrudAppService<
        Patient, //The Book entity
        PatientDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdatePatientDto>, //Used to create/update a book
    IPatientAppService //implement the IBookAppService
{
    public PatientAppService(IRepository<Patient, Guid> repository)
        : base(repository)
    {
        GetPolicyName = PatientSystemPermissions.Patients.Default;
        GetListPolicyName = PatientSystemPermissions.Patients.Default;
        CreatePolicyName = PatientSystemPermissions.Patients.Create;
        UpdatePolicyName = PatientSystemPermissions.Patients.Edit;
        DeletePolicyName = PatientSystemPermissions.Patients.Delete;
    }
}