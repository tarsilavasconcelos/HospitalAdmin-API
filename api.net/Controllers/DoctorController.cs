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
            List<Doctor> users = await _doctorRepository.SearchAllDoctors();
            return Ok(users);
        }

        [HttpGet("search/{id}")]
        public async Task<ActionResult<Doctor>> SearchById(int id)
        {
            var doctor = await _doctorRepository.SearchById(id);
            return Ok(doctor);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Doctor>> Register([FromBody] Doctor Doctor)
        {
            Doctor users = await _doctorRepository.Add(Doctor);
            return Ok(users);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Doctor>> Update([FromBody] Doctor Doctor, int id)
        {
            Doctor.Id = id;
            Doctor users = await _doctorRepository.Update(Doctor, id);
            return Ok(users);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Doctor>> Delete(int id)
        {
            bool deleteded = await _doctorRepository.Delete(id);
            return Ok(deleteded);
        }
    }
}
