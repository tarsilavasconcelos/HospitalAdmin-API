using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using api.net.Models.Entity;

namespace api.net.Data.Map
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                new Status()
                {
                    Id = 1,
                    StatusName = "Confirmado"
                },
                new Status()
                {
                    Id = 2,
                    StatusName = "Cancelado"
                }
            );
        }
    }
}