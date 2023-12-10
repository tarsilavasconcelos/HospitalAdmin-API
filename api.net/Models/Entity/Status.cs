using System.ComponentModel.DataAnnotations.Schema;

namespace api.net.Models.Entity
{
    [Table("tb_status")]
    public class Status
    {
        public int Id { get; set; }
        [Column("status_name")]
        public string? StatusName { get; set; }
    }
}
