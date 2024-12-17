namespace GraduationProject.DTO
{
    public class PatientDetailsDto
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public List<GetAllGuardiansDto> Gurdains { get; set; }  
        public GetMedicalHistoryDto MedicalHistory { get; set; }    
        public List<GetAllReportsDto> Reportes { get; set; }
    }
}
