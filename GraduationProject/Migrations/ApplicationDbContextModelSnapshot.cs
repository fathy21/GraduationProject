﻿// <auto-generated />
using System;
using GraduationProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraduationProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraduationProject.Models.Domain.Emergency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmergencyHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GurdianId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalStaffId")
                        .HasColumnType("int");

                    b.Property<int?>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GurdianId");

                    b.HasIndex("MedicalStaffId");

                    b.HasIndex("ToolId");

                    b.ToTable("emergencies");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Gurdian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("gurdians");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diagonsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("medicalHistory");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.MedicalStaff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("medicalStaff");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GurdianId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToolId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GurdianId");

                    b.HasIndex("MedicalStaffId");

                    b.HasIndex("ToolId");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthOfDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MedicalStaffId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("ReportDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicalStaffId");

                    b.HasIndex("PatientId");

                    b.ToTable("reports");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("BodyTemperature")
                        .HasColumnType("real");

                    b.Property<byte>("HeartRate")
                        .HasColumnType("tinyint");

                    b.Property<byte>("OxygenSaturation")
                        .HasColumnType("tinyint");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("QrCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VitalDataTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique()
                        .HasFilter("[PatientId] IS NOT NULL");

                    b.ToTable("tools");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Emergency", b =>
                {
                    b.HasOne("GraduationProject.Models.Domain.Gurdian", "Gurdian")
                        .WithMany("Emergencies")
                        .HasForeignKey("GurdianId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GraduationProject.Models.Domain.MedicalStaff", "MedicalStaff")
                        .WithMany("Emergencies")
                        .HasForeignKey("MedicalStaffId");

                    b.HasOne("GraduationProject.Models.Domain.Tool", "Tool")
                        .WithMany("Emergencies")
                        .HasForeignKey("ToolId");

                    b.Navigation("Gurdian");

                    b.Navigation("MedicalStaff");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Gurdian", b =>
                {
                    b.HasOne("GraduationProject.Models.Domain.Patient", "Patient")
                        .WithMany("Gurdians")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.MedicalHistory", b =>
                {
                    b.HasOne("GraduationProject.Models.Domain.Patient", "Patient")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("GraduationProject.Models.Domain.MedicalHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.MedicalStaff", b =>
                {
                    b.HasOne("GraduationProject.Models.Domain.Patient", "Patient")
                        .WithMany("medicalStaff")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Notification", b =>
                {
                    b.HasOne("GraduationProject.Models.Domain.Gurdian", "Gurdian")
                        .WithMany("Notification")
                        .HasForeignKey("GurdianId");

                    b.HasOne("GraduationProject.Models.Domain.MedicalStaff", "MedicalStaff")
                        .WithMany("Notification")
                        .HasForeignKey("MedicalStaffId");

                    b.HasOne("GraduationProject.Models.Domain.Tool", "Tool")
                        .WithMany("Notification")
                        .HasForeignKey("ToolId");

                    b.Navigation("Gurdian");

                    b.Navigation("MedicalStaff");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Report", b =>
                {
                    b.HasOne("GraduationProject.Models.Domain.MedicalStaff", "MedicalStaff")
                        .WithMany()
                        .HasForeignKey("MedicalStaffId");

                    b.HasOne("GraduationProject.Models.Domain.Patient", "Patient")
                        .WithMany("Reports")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("MedicalStaff");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Tool", b =>
                {
                    b.HasOne("GraduationProject.Models.Domain.Patient", "Patient")
                        .WithOne("Tool")
                        .HasForeignKey("GraduationProject.Models.Domain.Tool", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Gurdian", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.MedicalStaff", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Patient", b =>
                {
                    b.Navigation("Gurdians");

                    b.Navigation("MedicalHistory")
                        .IsRequired();

                    b.Navigation("Reports");

                    b.Navigation("Tool")
                        .IsRequired();

                    b.Navigation("medicalStaff");
                });

            modelBuilder.Entity("GraduationProject.Models.Domain.Tool", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Notification");
                });
#pragma warning restore 612, 618
        }
    }
}
