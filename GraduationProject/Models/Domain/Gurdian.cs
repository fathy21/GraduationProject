namespace GraduationProject.Models.Domain
{
    public class Gurdian
    {
        public int Id { get; set; } 
        public string Type { get; set; }     // father , mother , sis , bro , ....
        public string Name { get; set; }    
        public string PhoneNumber { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<Notification> Notification { get; set; } = new HashSet<Notification>();
        public ICollection<Emergency> Emergencies { get; set; } = new HashSet<Emergency>();
    }
}
