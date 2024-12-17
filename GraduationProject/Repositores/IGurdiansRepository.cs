using GraduationProject.DTO;
using GraduationProject.Models.Domain;

namespace GraduationProject.Repositores
{
    public interface IGurdiansRepository
    {
        Task<List<Gurdian>> GetAllAsync();
        Task<Gurdian?> GetById(int id);
        Task<Gurdian> Create(Gurdian medicalStaff);
        Task<Gurdian> Delete(int id);
        Task<Gurdian> Update(int id, Gurdian medicalStaff);
        Task<Gurdian> GetPatientByGurdianId(int id);
        Task<List<GetAllNotificationForGurdianDto>> GetAllNotificationForGurdian(int id);
        Task<List<GetAllEmergencyForGurdianDto>> GetAllEmergencyForGurdian(int id);
    }
}
