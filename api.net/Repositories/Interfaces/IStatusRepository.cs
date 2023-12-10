using api.net.Models.Entity;

namespace api.net.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        Task<List<Status>> SearchAllStatusAsync();
    }
}
