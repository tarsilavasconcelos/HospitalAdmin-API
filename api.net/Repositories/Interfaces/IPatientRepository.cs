using api.net.Models.Entity;

namespace api.net.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> SearchAllPatients();
        Task<Patient> SearchById(int id);
        Task<Patient> Add(Patient patient);
        Task<Patient> Update(Patient patient, int id);
        Task<bool> Delete(int id);
    }
}
