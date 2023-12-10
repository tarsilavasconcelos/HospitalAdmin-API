using api.net.Data.Map;
using api.net.Models;
using api.net.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace api.net.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Scheduling> Schedulings { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DoctorMap());
            modelBuilder.ApplyConfiguration(new PatientMap());
            modelBuilder.ApplyConfiguration(new SchedulingMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
