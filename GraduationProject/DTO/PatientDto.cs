using GraduationProject.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(MedicalHistory))]
        public int? MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public ICollection<MedicalStaff> medicalStaff { get; set; } = new HashSet<MedicalStaff>();
        public ICollection<Gurdian> Gurdians { get; set; } = new HashSet<Gurdian>();
    }
}
