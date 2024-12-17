using GraduationProject.Data;
using GraduationProject.DTO;
using GraduationProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Repositores
{
    public class GurdiansRepository : IGurdiansRepository
    {
        private readonly ApplicationDbContext _context;

        public GurdiansRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Gurdian> Create(Gurdian gurdian)
        {
            var guardian = await _context.gurdians.AddAsync(gurdian);
            await _context.SaveChangesAsync();
            return gurdian;
        }
        public async Task<List<Gurdian>> GetAllAsync()
        {
            return await _context.gurdians.ToListAsync();
        }
        public async Task<Gurdian?> GetById(int id)
        {
            return await _context.gurdians.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Gurdian> Delete(int id)
        {
            var guardian = await _context.gurdians.FirstOrDefaultAsync(x => x.Id == id);
            if (guardian == null)
            {
                return null;
            }
            _context.gurdians.Remove(guardian);
            await _context.SaveChangesAsync();
            return guardian;
        }
        public async Task<Gurdian> Update(int id, Gurdian gurdian)
        {
            var exestinggurdian = await _context.gurdians.FirstOrDefaultAsync(x => x.Id == id);
            if (exestinggurdian == null)
            {
                return null;
            }

            exestinggurdian.Name = gurdian.Name;
            exestinggurdian.Type = gurdian.Type;

            await _context.SaveChangesAsync();
            return exestinggurdian;
        }
        public Task<List<GetAllEmergencyForGurdianDto>> GetAllEmergencyForGurdian(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<GetAllNotificationForGurdianDto>> GetAllNotificationForGurdian(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Gurdian> GetPatientByGurdianId(int id)
        {
            return await _context.gurdians
                                 .Include(p => p.Patient)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
