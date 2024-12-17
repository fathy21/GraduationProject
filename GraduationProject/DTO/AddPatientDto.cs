using System.ComponentModel.DataAnnotations;

namespace GraduationProject.DTO
{
    public class AddPatientDto
    {
        [Required]
        public string SSN { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthOfDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
