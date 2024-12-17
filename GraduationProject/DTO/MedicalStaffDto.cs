using GraduationProject.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.DTO
{
    public class MedicalStaffDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        //1:M (patient:medicalstaff)
        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<Notification> Notification { get; set; } = new HashSet<Notification>();
        public ICollection<Emergency> Emergencies { get; set; } = new HashSet<Emergency>();
    }
}
