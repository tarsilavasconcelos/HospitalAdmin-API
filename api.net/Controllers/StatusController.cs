using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.net.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet("search-all-status")]
        public async Task<ActionResult<List<Status>>> SearchAllStatus()
        {
            try
            {
                List<Status> statuses = await _statusRepository.SearchAllStatusAsync();

                return Ok(statuses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
