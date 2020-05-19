using System;
using Cw11.DTOs;
using Cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        
        private readonly IDoctorsDbService _context;

        public DoctorsController(IDoctorsDbService context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetDoctors(int id)
        {
            var doctor = _context.GetDoctor(id);

            if (doctor == null)
                return NotFound();

            return Ok(_context.GetDoctor(id));
        }

        [HttpPatch("{id}")]
        public IActionResult ModifyDoctor(int id, DoctorModifyDto doctorDto)
        {
            var doctor = _context.ModifyDoctor(id,doctorDto);

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult AddDoctor(DoctorAddDto doctorDto)
        {
            var doctor = _context.AddDoctor(doctorDto);

            return Ok(doctor);
        }
        
        [HttpDelete("{id}")]
        public IActionResult RemoveDoctor(int id)
        {
            var doctor = _context.RemoveDoctor(id);

            if (doctor == null)
                return NotFound();
            
            return Ok(doctor);
        }
    }
}