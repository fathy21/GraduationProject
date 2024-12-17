using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models.Domain
{
    public class Patient
    {
        public int Id {  get; set; }    
        public string SSN { get; set; }    
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }   
        public string Gender { get; set; }  
        public string PhoneNumber { get; set; }
        public Tool Tool { get; set; }  
        public MedicalHistory MedicalHistory { get; set;}
        public ICollection<MedicalStaff> medicalStaff { get; set; } = new HashSet<MedicalStaff>();  
        public ICollection<Gurdian> Gurdians { get; set; }  = new HashSet<Gurdian>();   
        public ICollection<Report> Reports { get; set; } = new HashSet<Report>();    
    }
}
