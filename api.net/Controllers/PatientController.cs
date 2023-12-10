using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.net.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet("search-all-patients")]
        public async Task<ActionResult<List<Patient>>> SearchAllPatients()
        {
            try
            {
                List<Patient> patients = await _patientRepository.SearchAllPatients();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<Patient>> Register([FromBody] Patient Patient)
        {
            try
            {
                Patient patient = await _patientRepository.Add(Patient);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Patient>> Update([FromBody] Patient Patient, int id)
        {
            try
            {
                Patient.Id = id;
                Patient patient = await _patientRepository.Update(Patient, id);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Patient>> Delete(int id)
        {
            try
            {
                bool deleteded = await _patientRepository.Delete(id);
                return Ok(deleteded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
