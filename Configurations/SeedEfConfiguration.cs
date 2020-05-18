using System;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Cw11.Configurations
{
    public static class SeedEfConfiguration
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {
                    IdDoctor = 1,
                    Email = "aaa@wp.pl",
                    FirstName = "Adam",
                    LastName = "Nowak"
                }, new Doctor
                {
                    IdDoctor = 2,
                    Email = "bbb@wp.pl",
                    FirstName = "Tomasz",
                    LastName = "Kowalski"
                });
            
            modelBuilder.Entity<Patient>().HasData(
                new Patient {
                    IdPatient = 2,
                    Birthdate = DateTime.Today,
                    FirstName = "Witold",
                    LastName = "Czapek"
                }, new Patient
                {
                    IdPatient = 1,
                    Birthdate = DateTime.Today,
                    FirstName = "Janusz",
                    LastName = "Korwin"
                });

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Today,
                    DueDate = DateTime.Today,
                    IdDoctor = 1,
                    IdPatient = 1,
                });
            modelBuilder.Entity<Medicament>().HasData(
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Apap",
                    Description = "na bol",
                    Type = "zwykly"
                });
            
            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 1,
                    Details = "ssss"
                });
        }
    }
}