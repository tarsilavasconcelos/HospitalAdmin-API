using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace api.net.Controllers
{
    [Route("api/scheduling")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public SchedulingController(ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
        }

        [HttpGet("search-all-schedulings")]
        public async Task<ActionResult<List<Scheduling>>> SearchAllSchedulings()
        {
            List<Scheduling> users = await _schedulingRepository.SearchAllSchedulings();
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Scheduling>> Register([FromBody] Scheduling Scheduling)
        {
            Scheduling users = await _schedulingRepository.Add(Scheduling);
            return Ok(users);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Scheduling>> Update([FromBody] Scheduling Scheduling, int id)
        {
            Scheduling.Id = id;
            Scheduling users = await _schedulingRepository.Update(Scheduling, id);
            return Ok(users);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Scheduling>> Delete(int id)
        {
            bool deleteded = await _schedulingRepository.Delete(id);
            return Ok(deleteded);
        }
    }
}
