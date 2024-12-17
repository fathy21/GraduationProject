namespace GraduationProject.Models.Domain
{
    public class Tool
    {
        public int Id { get; set; }
        public byte OxygenSaturation { get; set; } // نسبة الأكسجين
        public float BodyTemperature { get; set; } // درجة الحرارة
        public DateTime VitalDataTimestamp { get; set; } // وقت القياس
        public byte HeartRate { get; set; } 
        public string QrCode { get; set; }  
        public int? PatientId { get; set; } 
        public Patient? Patient { get; set; }
        public ICollection<Notification> Notification { get; set; } = new HashSet<Notification>();  
        public ICollection<Emergency> Emergencies { get; set; } = new HashSet<Emergency>(); 

    }
}
