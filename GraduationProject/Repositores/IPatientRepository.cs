using GraduationProject.DTO;
using GraduationProject.Models.Domain;

namespace GraduationProject.Repositores
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAll(int pageNumber = 1, int pageSize = 1000);
        Task<Patient?> GetById(int id);  
        Task<Patient>GetByName(string name);
        Task<Patient>Create(Patient patient);
        Task<Patient> Delete(int id);   
        Task<List<GetAllMedicalStaffForPateintDto>> GetMedicalStaffForPatient(int id);
        Task<List<GetAllGuardiansDto>> GetAllGuardiansForPateint(int id);
        Task<GetMedicalHistoryDto> GetMedicalHistoryDtoForPateint(int id);
        Task<List<GetAllReportsDto>> GetReportsForPatient(int id);
        Task<PatientDetailsDto> GetPatientDetails(int id);
    }
}
