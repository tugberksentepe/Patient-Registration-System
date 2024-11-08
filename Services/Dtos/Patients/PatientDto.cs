using PatientSystem.Entities.Patients;
using Volo.Abp.Application.Dtos;

namespace PatientSystem.Services.Dtos.Patients;

public class PatientDto : AuditedEntityDto<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public DateTime AdmissionDate { get; set; }
    public PatientStatus Status { get; set; }
    public string Notes { get; set; }
    
}