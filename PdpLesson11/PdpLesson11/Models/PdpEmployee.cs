using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhamDinhPhung_2310900083.Models
{
    [Table("PdpEmployee")]
    public partial class PdpEmployee
    {
        [Key]
        [Column("PdpEmpId")]
        public int PdpEmpId { get; set; }

        [Column("PdpEmpName")]
        [StringLength(100)]
        public string? PdpEmpName { get; set; }

        [Column("PdpEmpLevel")]
        [StringLength(50)]
        public string? PdpEmpLevel { get; set; }

        [Column("PdpEmpStartDate", TypeName = "datetime")]
        public DateTime? PdpEmpStartDate { get; set; }

        [Column("PdpEmpStatus")]
        public bool? PdpEmpStatus { get; set; }
    }
}
