using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models.Domain
{
    public class MedicalHistory
    {
        public int Id { get; set; } 
        public string Diagonsis { get; set; }    // تشخيص
        public string Medication { get; set; }  // دواء
        //(1:1)
        [ForeignKey(nameof(Patient))]    
        public int PatientId { get; set; }  
        public Patient Patient { get; set; }    
    }
}
