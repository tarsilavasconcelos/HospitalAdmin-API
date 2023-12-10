using api.net.Data;
using api.net.Models;
using api.net.Models.Entity;
using api.net.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.net.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DBContext _dbContext;
        public DoctorRepository(DBContext DBContext)
        {
            _dbContext = DBContext;

        }
        public async Task<Doctor> SearchById(int id)
        {
            return await _dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Doctor>> SearchAllDoctors()
        {
            return await _dbContext.Doctors.ToListAsync();
        }
        public async Task<Doctor> Add(Doctor doctor)
        {
            var doctorEntity = new Doctor()
            {
                Name = doctor.Name,
                Email = doctor.Email
            };
            await _dbContext.Doctors.AddAsync(doctorEntity);
            await _dbContext.SaveChangesAsync();

            return doctorEntity;
        }

        public async Task<Doctor> Update(Doctor doctor, int id)
        {
            Doctor doctorPorId = await SearchById(id);

            if (doctorPorId == null)
            {
                throw new Exception($"Usuario Para o ID: {id} não foi identificado no banco de dados.");
            }

            doctorPorId.Name = doctor.Name;
            doctorPorId.Email = doctor.Email;

            _dbContext.Doctors.Update(doctorPorId);
            await _dbContext.SaveChangesAsync();

            return doctorPorId;

        }

        public async Task<bool> Delete(int id)
        {
            Doctor doctorPorId = await SearchById(id);

            if (doctorPorId == null)
            {
                throw new Exception($"Usuario Para o ID: {id} não foi identificado no banco de dados.");
            }
            _dbContext.Doctors.Remove(doctorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
