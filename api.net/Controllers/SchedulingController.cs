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
            try
            {
                List<Scheduling> schedulings = await _schedulingRepository.SearchAllSchedulings();
                return Ok(schedulings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpGet("search/{id}")]
        public async Task<ActionResult<Scheduling>> SearchSchedulingById(int id)
        {
            try
            {
                Scheduling scheduling = await _schedulingRepository.SearchById(id);
                return Ok(scheduling);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<Scheduling>> Register([FromBody] Scheduling Scheduling)
        {
            try
            {
                Scheduling scheduling = await _schedulingRepository.Add(Scheduling);
                return Ok(scheduling);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Scheduling>> Update([FromBody] Scheduling Scheduling, int id)
        {
            try
            {
                Scheduling.Id = id;
                Scheduling scheduling = await _schedulingRepository.Update(Scheduling, id);
                return Ok(scheduling);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Scheduling>> Delete(int id)
        {
            try
            {
                bool deleteded = await _schedulingRepository.Delete(id);
                return Ok(deleteded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut("confirm/{id}")]
        public async Task<ActionResult<Scheduling>> Confirm(int id)
        {
            try
            {
                bool confirmed = await _schedulingRepository.Confirm(id);
                return Ok(confirmed);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
