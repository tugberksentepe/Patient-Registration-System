using AutoMapper;
using PatientSystem.Entities.Patients;
using PatientSystem.Services.Dtos.Patients;

namespace PatientSystem.ObjectMapping;

public class PatientSystemAutoMapperProfile : Profile
{
    public PatientSystemAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        
        CreateMap<Patient, PatientDto>();
        CreateMap<CreateUpdatePatientDto, Patient>();
        CreateMap<PatientDto, CreateUpdatePatientDto>();
    }
}
