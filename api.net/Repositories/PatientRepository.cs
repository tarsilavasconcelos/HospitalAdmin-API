using api.net.Data;
using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.net.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DBContext _dbContext;
        public PatientRepository(DBContext DBContext)
        {
            _dbContext = DBContext;
        }
        public async Task<Patient> SearchById(int id)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<List<Patient>> SearchAllPatients()
        {
            return await _dbContext.Patients.ToListAsync();
        }
        public async Task<Patient> Add(Patient patient)
        {
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();

            return patient;
        }
        public async Task<Patient> Update(Patient patient, int id)
        {
            Patient patientPorId = await SearchById(id);

            if (patientPorId == null)
            {
                throw new Exception($"Usuario Para o ID: {id} nao foi identificado no banco de dados.");
            }
            patientPorId.Name = patient.Name;
            patientPorId.Email = patient.Email;

            _dbContext.Patients.Update(patientPorId);
            await _dbContext.SaveChangesAsync();

            return patientPorId;
        }
        public async Task<bool> Delete(int id)
        {
            Patient patientPorId = await SearchById(id);

            if (patientPorId == null)
            {
                throw new Exception($"Usuario Para o ID: {id} não foi identificado no banco de dados.");
            }
            _dbContext.Patients.Remove(patientPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
