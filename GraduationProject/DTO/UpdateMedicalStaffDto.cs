using System.ComponentModel.DataAnnotations;

namespace GraduationProject.DTO
{
    public class UpdateMedicalStaffDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Role { get; set; }
    }
}
