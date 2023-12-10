using api.net.Data;
using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.net.Repositories
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly DBContext _dbContext;
        public SchedulingRepository(DBContext DBContext)
        {
            _dbContext = DBContext;
        }
        public async Task<Scheduling> SearchById(int id)
        {
            return await _dbContext.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Scheduling>> SearchAllSchedulings()
        {
            return await _dbContext.Schedulings.ToListAsync();
        }
        public async Task<Scheduling> Add(Scheduling scheduling)
        {
            await _dbContext.Schedulings.AddAsync(scheduling);
            await _dbContext.SaveChangesAsync();

            return scheduling;
        }
        public async Task<Scheduling> Update(Scheduling scheduling, int id)
        {
            Scheduling schedulingPorId = await SearchById(id);
            if (schedulingPorId == null)
            {
                throw new Exception($"Usuario Para o ID: {id} nao foi identificado no banco de dados.");
            }

            schedulingPorId.Description = scheduling.Description;
            schedulingPorId.StatusId = scheduling.StatusId;
            // schedulingPorId.DoctorId = scheduling.DoctorId;
            // schedulingPorId.PatientId = scheduling.PatientId;
            schedulingPorId.SchedulingDate = scheduling.SchedulingDate;

            _dbContext.Schedulings.Update(schedulingPorId);
            await _dbContext.SaveChangesAsync();

            return schedulingPorId;
        }
        public async Task<bool> Delete(int id)
        {
            Scheduling schedulingPorId = await SearchById(id);

            if (schedulingPorId == null)
            {
                throw new Exception($"Usuario Para o ID: {id} não foi identificado no banco de dados.");
            }

            _dbContext.Schedulings.Remove(schedulingPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
