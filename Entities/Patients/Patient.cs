using Volo.Abp.Domain.Entities.Auditing;

namespace PatientSystem.Entities.Patients;

public class Patient : AuditedAggregateRoot<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public DateTime AdmissionDate { get; set; }
    public PatientStatus Status { get; set; }
    public string Notes { get; set; }
}






