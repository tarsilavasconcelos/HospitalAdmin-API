using System.ComponentModel.DataAnnotations.Schema;

namespace api.net.Models.Entity
{
    [Table("tb_patients")]
    public class Patient
    {
        public int Id { get; set; }
        [Column("patient_name")]
        public string? Name { get; set; }
        [Column("patient_email")]
        public string? Email { get; set; }
    }
}
