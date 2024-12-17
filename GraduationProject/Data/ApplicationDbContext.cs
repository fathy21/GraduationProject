using GraduationProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Patient> patients { get; set; }    
        public DbSet<Tool> tools { get; set; }  
        public DbSet<Gurdian> gurdians { get; set; }    
        public DbSet<MedicalHistory> medicalHistory { get; set;}
        public DbSet<MedicalStaff> medicalStaff { get; set; }   
        public DbSet<Emergency> emergencies { get; set; }
        public DbSet<Notification> notifications { get; set; }   
        public DbSet<Report> reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Gurdian>()
                .HasOne(g => g.Patient)
                .WithMany(p => p.Gurdians)
                .HasForeignKey(g => g.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                 modelBuilder.Entity<MedicalStaff>()
                .HasOne(x=>x.Patient)
                .WithMany(x=>x.medicalStaff)
                .HasForeignKey(x=>x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                 modelBuilder.Entity<MedicalHistory>()
                .HasOne(x=>x.Patient)
                .WithOne(p => p.MedicalHistory)
                .HasForeignKey<MedicalHistory>(x=>x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Report>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

                 modelBuilder.Entity<Tool>()
                .HasOne(x => x.Patient)
                .WithOne(p => p.Tool)
                .HasForeignKey<Tool>(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Emergency>()
                .HasOne(x=>x.Gurdian)
                .WithMany(x=>x.Emergencies)
                .HasForeignKey(x=>x.GurdianId)
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
