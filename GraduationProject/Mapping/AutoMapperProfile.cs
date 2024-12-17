using AutoMapper;
using GraduationProject.DTO;
using GraduationProject.Models.Domain;

namespace GraduationProject.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //mapping 
            CreateMap<AddPatientDto , Patient>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<MedicalStaff, GetAllMedicalStaffForPateintDto>().ReverseMap();
            CreateMap<Gurdian , GetAllGuardiansDto>().ReverseMap();
            CreateMap<MedicalHistory, GetMedicalHistoryDto>().ReverseMap();
            CreateMap<Report, GetAllReportsDto>().ReverseMap();
            CreateMap<AddMedicalStaffDto , MedicalStaff>().ReverseMap();
            CreateMap<MedicalStaffDto, MedicalStaff>().ReverseMap();
            CreateMap<UpdateMedicalStaffDto, MedicalStaff>().ReverseMap();
            CreateMap<GetPatientByMedicalStaff, Patient>().ReverseMap();
            CreateMap<GetAllEmergencyForMedicalStaffDto , Emergency>().ReverseMap();
        }
    }
}
