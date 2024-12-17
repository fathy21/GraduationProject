namespace GraduationProject.Models.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }    
        public string ReportDetails { get; set; }   
        public int? PatientId { get; set; }    
        public Patient Patient { get; set; }    
        public int? MedicalStaffId { get; set; }    
        public MedicalStaff MedicalStaff { get; set;}  
    }
}
