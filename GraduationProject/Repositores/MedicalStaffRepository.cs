using GraduationProject.Data;
using GraduationProject.DTO;
using GraduationProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Repositores
{
    public class MedicalStaffRepository : IMedicalStaffRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MedicalStaffRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MedicalStaff> Create(MedicalStaff medicalStaff)
        {
            var medicalsatff = await _dbContext.medicalStaff.AddAsync(medicalStaff);    
            await _dbContext.SaveChangesAsync();
            return medicalStaff;
        }

        public async Task<MedicalStaff> Delete(int id)
        {
            var medicalstaff = await _dbContext.medicalStaff.FirstOrDefaultAsync(x => x.Id == id);
            if(medicalstaff == null)
            {
                return null;
            }
            _dbContext.medicalStaff.Remove(medicalstaff);
            await _dbContext.SaveChangesAsync();
            return medicalstaff;
        }

        public async Task<List<MedicalStaff>> GetAllAsync()
        {
            return await _dbContext.medicalStaff.ToListAsync();
        }

        public async Task<List<GetAllEmergencyForMedicalStaffDto>> GetAllEmergencyForMedicalStaff(int id)
        {
            var medicalStaff = await _dbContext.medicalStaff
                .Include(x => x.Emergencies)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (medicalStaff == null)
            {
                return null;
            }

            return medicalStaff.Emergencies
                .Select(x => new GetAllEmergencyForMedicalStaffDto
                {
                    Id = x.Id,
                    EmergencyHistory = x.EmergencyHistory
                }).ToList();

        }

        public async Task<List<GetAllNotificationForMedicalStaffDto>> GetAllNotificationForMedicalStaff(int id)
        {
            var medicalStaff = await _dbContext.medicalStaff
                .Include(x=>x.Notification)
                .FirstOrDefaultAsync(x=>x.Id == id);
            
            if(medicalStaff == null)
            {
                return null;
            }
             
            return medicalStaff
                .Notification
                .Select(x=> new GetAllNotificationForMedicalStaffDto
                {
                    Date = x.Date,
                    Message = x.Message,
                    Status = x.Status,
                    Id = x.Id,
                    Type = x.Type
                }).ToList();
        }

        public async Task<MedicalStaff?> GetById(int id)
        {
            return await _dbContext.medicalStaff.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<MedicalStaff> GetByName(string name)
        {
            return await _dbContext.medicalStaff.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<MedicalStaff> GetPatientForMedicalStaff(int id)
        {
            return await _dbContext.medicalStaff
                .Include(x => x.Patient)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MedicalStaff> Update(int id, MedicalStaff medicalStaff)
        {
            var exestingmedicalstaff = await _dbContext.medicalStaff.FirstOrDefaultAsync(x=>x.Id == id);  
            if(exestingmedicalstaff == null)
            {
                return null;
            }

            exestingmedicalstaff.Name = medicalStaff.Name;
            exestingmedicalstaff.Role = medicalStaff.Role;

            await _dbContext.SaveChangesAsync();
            return exestingmedicalstaff;
        }
    }
}
