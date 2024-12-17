namespace GraduationProject.Models.Domain
{
    public class Notification
    {
        public int Id { get; set; } 
        public string Message { get; set; } 
        public string Type { get; set; }    
        public DateTime Date { get; set; }  
        public string Status { get; set; }  
        public int? GurdianId { get; set; }  //1:m
        public Gurdian Gurdian { get; set; }       
        public int? ToolId { get; set; }     //1:m
        public Tool Tool { get; set; }  
        public int? MedicalStaffId { get; set; }    //1:m
        public MedicalStaff MedicalStaff { get; set; }
    }
}
