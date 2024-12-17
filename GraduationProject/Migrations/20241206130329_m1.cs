using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gurdians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gurdians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gurdians_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagonsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalHistory_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicalStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalStaff_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OxygenSaturation = table.Column<byte>(type: "tinyint", nullable: false),
                    BodyTemperature = table.Column<float>(type: "real", nullable: false),
                    VitalDataTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeartRate = table.Column<byte>(type: "tinyint", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tools_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    MedicalStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reports_medicalStaff_MedicalStaffId",
                        column: x => x.MedicalStaffId,
                        principalTable: "medicalStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reports_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergencyHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianId = table.Column<int>(type: "int", nullable: true),
                    ToolId = table.Column<int>(type: "int", nullable: true),
                    MedicalStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emergencies_gurdians_GurdianId",
                        column: x => x.GurdianId,
                        principalTable: "gurdians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emergencies_medicalStaff_MedicalStaffId",
                        column: x => x.MedicalStaffId,
                        principalTable: "medicalStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_emergencies_tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "tools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GurdianId = table.Column<int>(type: "int", nullable: true),
                    ToolId = table.Column<int>(type: "int", nullable: true),
                    MedicalStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_gurdians_GurdianId",
                        column: x => x.GurdianId,
                        principalTable: "gurdians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notifications_medicalStaff_MedicalStaffId",
                        column: x => x.MedicalStaffId,
                        principalTable: "medicalStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notifications_tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "tools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_emergencies_GurdianId",
                table: "emergencies",
                column: "GurdianId");

            migrationBuilder.CreateIndex(
                name: "IX_emergencies_MedicalStaffId",
                table: "emergencies",
                column: "MedicalStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_emergencies_ToolId",
                table: "emergencies",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_gurdians_PatientId",
                table: "gurdians",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalHistory_PatientId",
                table: "medicalHistory",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicalStaff_PatientId",
                table: "medicalStaff",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_GurdianId",
                table: "notifications",
                column: "GurdianId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_MedicalStaffId",
                table: "notifications",
                column: "MedicalStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_ToolId",
                table: "notifications",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_MedicalStaffId",
                table: "reports",
                column: "MedicalStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_PatientId",
                table: "reports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tools_PatientId",
                table: "tools",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emergencies");

            migrationBuilder.DropTable(
                name: "medicalHistory");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "gurdians");

            migrationBuilder.DropTable(
                name: "tools");

            migrationBuilder.DropTable(
                name: "medicalStaff");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
