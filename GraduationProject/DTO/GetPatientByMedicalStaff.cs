namespace GraduationProject.DTO
{
    public class GetPatientByMedicalStaff
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
