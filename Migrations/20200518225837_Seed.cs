using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "aaa@wp.pl", "Adam", "Nowak" },
                    { 2, "bbb@wp.pl", "Tomasz", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[] { 1, "na bol", "Apap", "zwykly" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Local), "Witold", "Czapek" },
                    { 1, new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Local), "Janusz", "Korwin" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose" },
                values: new object[] { 1, 1, "ssss", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdPrescription", "IdMedicament" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);
        }
    }
}
