using GraduationProject.Data;
using GraduationProject.DTO;
using GraduationProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Repositores
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Patient> Create(Patient patient)
        {
            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> Delete(int id)
        {
            var existingPatient = await _context.patients
                .Include(p => p.Gurdians)
                .Include(p => p.medicalStaff)
                .Include(p => p.MedicalHistory)
                .Include(p => p.Reports)
                .Include(p => p.Tool)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPatient == null)
            {
                return null;
            }

            try
            {
                // Remove related entities
                await RemoveRelatedEntities(existingPatient);

                // Now remove the patient
                _context.patients.Remove(existingPatient);
                await _context.SaveChangesAsync();

                return existingPatient;
            }
            catch (Exception ex)
            {
                // Log the exception
                // Log.Error(ex, "An error occurred while deleting the patient.");
                return null;
            }
        }

        private async Task RemoveRelatedEntities(Patient patient)
        {
            if (patient.Gurdians != null && patient.Gurdians.Any())
            {
                _context.gurdians.RemoveRange(patient.Gurdians);
            }

            if (patient.Reports != null && patient.Reports.Any())
            {
                _context.reports.RemoveRange(patient.Reports);
            }

            if (patient.medicalStaff != null && patient.medicalStaff.Any())
            {
                _context.medicalStaff.RemoveRange(patient.medicalStaff);
            }

            if (patient.MedicalHistory != null)
            {
                _context.medicalHistory.Remove(patient.MedicalHistory);
            }

            if (patient.Tool != null)
            {
                _context.tools.Remove(patient.Tool);
            }
        }


        public async Task<List<Patient>> GetAll(int pageNumber = 1, int pageSize = 1000)
        {
            
            var skipresults = (pageNumber - 1) * pageSize; 
            return await _context.patients.Skip(skipresults).Take(pageSize).ToListAsync();   
        }

        public async Task<Patient?> GetById(int id)
        {
            var patient = await _context.patients.FirstOrDefaultAsync(x => x.Id == id);
            return patient;
        }

        public async Task<Patient> GetByName(string name)
        {
            return await _context.patients.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<List<GetAllMedicalStaffForPateintDto>> GetMedicalStaffForPatient(int id)
        {
            var patient = await _context.patients
                .Where(x => x.Id == id)
                .Include(x => x.medicalStaff) // Include related medicalStaff
                .FirstOrDefaultAsync();

            if (patient == null)
            {
                return null; // Patient not found
            }

            // Map MedicalStaff to GetAllMedicalStaffForPateintDto
            return patient.medicalStaff
                .Select(x => new GetAllMedicalStaffForPateintDto
                {
                    Name = x.Name
                })
                .ToList();
        }
        public async Task<List<GetAllGuardiansDto>> GetAllGuardiansForPateint(int id)
        {
            var patient = await _context.patients
                .Where(x => x.Id == id)
                .Include(x => x.Gurdians)
                .FirstOrDefaultAsync();

            if (patient == null)
            {
                return null;
            }

            return patient.Gurdians
                .Select(x => new GetAllGuardiansDto
                {
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Type = x.Type
                })
                .ToList();
        }

        public async Task<GetMedicalHistoryDto> GetMedicalHistoryDtoForPateint(int id)
        {
            var patient = await _context.patients
                .Where(x => x.Id == id) 
                .Include(x=>x.MedicalHistory)
                .FirstOrDefaultAsync();

            if(patient == null || patient.MedicalHistory == null)
            {
                return null;
            }

                return new GetMedicalHistoryDto
                {
                    Diagonsis = patient.MedicalHistory.Diagonsis,
                    Id = patient.MedicalHistory.Id,
                    Medication= patient.MedicalHistory.Medication
                };
        }

        public async Task<List<GetAllReportsDto>> GetReportsForPatient(int id)
        {
            var patient = await _context.patients
                .Where(x => x.Id == id)
                .Include(x => x.Reports)
                .FirstOrDefaultAsync();

            if(patient == null)
            {
                return null;
            }

            return patient.Reports
                .Select(x => new GetAllReportsDto
                {
                    Id = x.Id,
                    ReportDetails = x.ReportDetails,    
                    UploadDate = x.UploadDate
                })
                .ToList();
        }

        public async Task<PatientDetailsDto> GetPatientDetails(int id)
        {
            var patient = await _context.patients
                .Where(x => x.Id == id)
                .Include(x => x.Gurdians)
                .Include(x => x.MedicalHistory)
                .Include(x => x.Reports)
                .FirstOrDefaultAsync();

            if(patient == null)
            {
                return null;
            }

            return new PatientDetailsDto
            {
                Id = patient.Id,
                Name = patient.Name,
                SSN = patient.SSN,
                Gender = patient.Gender,

                Gurdains = patient.Gurdians.Select(x => new GetAllGuardiansDto
                {
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Type = x.Type
                }).ToList(),

                MedicalHistory = patient.MedicalHistory == null  ? null 
                : new GetMedicalHistoryDto
                {
                    Id = patient.MedicalHistory.Id,
                    Diagonsis = patient.MedicalHistory.Diagonsis,
                    Medication = patient.MedicalHistory.Medication
                },

                Reportes = patient.Reports.Select(x=> new GetAllReportsDto
                {
                    Id = x.Id,
                    UploadDate = x.UploadDate,  
                    ReportDetails = x.ReportDetails
                }).ToList()
            };
        }
    }
}
