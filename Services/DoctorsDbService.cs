using System.Collections.Generic;
using System.Linq;
using Cw11.DTOs;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw11.Services
{
    public class DoctorsDbService : IDoctorsDbService
    {
        private readonly CodeFirstContext _context;
        public DoctorsDbService(CodeFirstContext context)
        {
            _context = context;
        }

        public Doctor GetDoctor(int id)
        {
            return _context.Doctor.First(x=>x.IdDoctor==id);
        }

        public Doctor ModifyDoctor(int id, DoctorModifyDto doctor)
        {
            _context.Doctor.Where(x=>x.IdDoctor==id).ToList().ForEach(x =>
            {
                x.Email = doctor.Email;
                x.FirstName = doctor.FirstName;
                x.LastName = doctor.LastName;
            });
            _context.SaveChanges();

            return GetDoctor(id);
        }

        public Doctor AddDoctor(DoctorAddDto doctor)
        {
            var doc = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            _context.Doctor.Add(doc);
            _context.SaveChanges();

            return GetDoctor(doc.IdDoctor);
        }

        public Doctor RemoveDoctor(int id)
        {
            var doctor = _context.Doctor.First(x => x.IdDoctor == id);
            _context.Remove(doctor);
            _context.SaveChanges();

            return doctor;
        }
    }
}