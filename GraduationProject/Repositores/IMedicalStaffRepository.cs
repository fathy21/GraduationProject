using GraduationProject.DTO;
using GraduationProject.Models.Domain;

namespace GraduationProject.Repositores
{
    public interface IMedicalStaffRepository
    {
        Task<List<MedicalStaff>> GetAllAsync();
        Task<MedicalStaff?> GetById(int id);
        Task<MedicalStaff> GetByName(string name);
        Task<MedicalStaff> Create(MedicalStaff medicalStaff);
        Task<MedicalStaff> Delete(int id);
        Task<MedicalStaff> Update (int id , MedicalStaff medicalStaff);
        Task<MedicalStaff> GetPatientForMedicalStaff(int id);
        Task<List<GetAllNotificationForMedicalStaffDto>> GetAllNotificationForMedicalStaff(int id);
        Task<List<GetAllEmergencyForMedicalStaffDto>> GetAllEmergencyForMedicalStaff(int id);
    }
}
