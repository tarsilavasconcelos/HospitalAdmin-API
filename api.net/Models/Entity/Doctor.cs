using System.ComponentModel.DataAnnotations.Schema;

namespace api.net.Models.Entity
{
    [Table("tb_doctors")]
    public class Doctor
    {
        public int Id { get; set; }
        [Column("doctor_name")]
        public string? Name { get; set; }
        [Column("doctor_email")]
        public string? Email { get; set; }
    }
}
