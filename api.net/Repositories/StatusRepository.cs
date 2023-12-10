using api.net.Data;
using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.net.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DBContext _dbContext;
        public StatusRepository(DBContext DBContext)
        {
            _dbContext = DBContext;
        }

        public async Task<List<Status>> SearchAllStatusAsync()
        {
            return await _dbContext.Status.ToListAsync();
        }
    }
}
