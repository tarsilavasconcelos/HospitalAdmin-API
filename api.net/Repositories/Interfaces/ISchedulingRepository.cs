using api.net.Models.Entity;

namespace api.net.Repositories.Interfaces
{
    public interface ISchedulingRepository
    {
        Task<List<Scheduling>> SearchAllSchedulings();
        Task<Scheduling> SearchById(int id);
        Task<Scheduling> Add(Scheduling scheduling);
        Task<Scheduling> Update(Scheduling scheduling, int id);
        Task<bool> Delete(int id);
        Task<bool> Confirm(int id);
    }
}
