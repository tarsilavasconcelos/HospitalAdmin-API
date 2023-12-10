using api.net.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.net.Data.Map
{
    public class SchedulingMap : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.DoctorId).IsRequired();
            builder.Property(x => x.PatientId).IsRequired();
            builder.HasOne(p => p.Patient).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Doctor).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.SchedulingDate).IsRequired();
            builder.Property(x => x.StatusId).IsRequired();

        }
    }
}
