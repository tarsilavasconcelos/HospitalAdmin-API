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
            List<Patient> patients = await _patientRepository.SearchAllPatients();
            return Ok(patients);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Patient>> Register([FromBody] Patient Patient)
        {
            Patient patient = await _patientRepository.Add(Patient);
            return Ok(patient);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Patient>> Update([FromBody] Patient Patient, int id)
        {
            Patient.Id = id;
            Patient patient = await _patientRepository.Update(Patient, id);
            return Ok(patient);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Patient>> Delete(int id)
        {
            bool deleteded = await _patientRepository.Delete(id);
            return Ok(deleteded);
        }

    }
}
