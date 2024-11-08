using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using PatientSystem.Entities.Patients;

namespace PatientSystem.Services.Dtos.Patients;

public class CreateUpdatePatientDto
{
    [Required]
    [StringLength(128)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    public int Age { get; set; } 
    
    [Required]
    public Gender Gender { get; set; } = Gender.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime AdmissionDate { get; set; } = DateTime.Now;

    [Required] public PatientStatus Status { get; set; } = PatientStatus.AnyProcessNotDefined;

    [Required] 
    [StringLength(512)] 
    public string Notes { get; set; } = string.Empty;
}