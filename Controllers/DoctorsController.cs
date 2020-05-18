using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        public IActionResult GetDoctors()
        {
            return Ok();
        }
    }
}