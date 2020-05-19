using System.Collections.Generic;
using Cw11.DTOs;
using Cw11.Models;

namespace Cw11.Services
{
    public interface IDoctorsDbService
    {
        public Doctor GetDoctor(int id);
        public Doctor ModifyDoctor(int id, DoctorModifyDto doctor);
        public Doctor AddDoctor(DoctorAddDto doctor);
        public Doctor RemoveDoctor(int id);
    }
}