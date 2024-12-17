namespace GraduationProject.Models.Domain
{
    public class Emergency
    {
        public int Id { get; set;}
        public string EmergencyHistory { get; set; }
        public int? GurdianId { get; set; }  //1:m
        public Gurdian Gurdian { get; set; }
        public int? ToolId { get; set; }     //1:m
        public Tool Tool { get; set; }
        public int? MedicalStaffId { get; set; }    //1:m
        public MedicalStaff MedicalStaff { get; set; }
    }
}
