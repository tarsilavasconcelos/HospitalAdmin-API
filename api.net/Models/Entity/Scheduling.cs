using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.net.Models.Entity
{
    [Table("tb_scheduling")]
    public class Scheduling
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        [Column("scheduling_date")]
        public DateTime? SchedulingDate { get; set; }
        [Column("status_id")]
        public int StatusId { get; set; }
        public Status? Status { get; set; }

    }
}
