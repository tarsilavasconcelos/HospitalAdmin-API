using api.net.Models;
using api.net.Models.Entity;

namespace api.net.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> SearchAllDoctors();
        Task<Doctor> SearchById(int id);
        Task<Doctor> Add(Doctor doctor);
        Task<Doctor> Update(Doctor doctor, int id);
        Task<bool> Delete(int id);

    }
}
