using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.net.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet("search-all-doctors")]
        public async Task<ActionResult<List<Doctor>>> SearchAllDoctors()
        {
            try
            {
                List<Doctor> doctors = await _doctorRepository.SearchAllDoctors();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet("search/{id}")]
        public async Task<ActionResult<Doctor>> SearchById(int id)
        {
            try
            {
                var doctor = await _doctorRepository.SearchById(id);
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<Doctor>> Register([FromBody] Doctor Doctor)
        {
            try
            {
                Doctor doctor = await _doctorRepository.Add(Doctor);
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Doctor>> Update([FromBody] Doctor Doctor, int id)
        {
            try
            {
                Doctor.Id = id;
                Doctor doctor = await _doctorRepository.Update(Doctor, id);
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Doctor>> Delete(int id)
        {
            try
            {
                bool deleteded = await _doctorRepository.Delete(id);
                return Ok(deleteded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
