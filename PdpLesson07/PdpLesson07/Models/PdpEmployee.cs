using System;
using System.ComponentModel.DataAnnotations;

namespace Pdplesson07.Models
{
    public class PdpEmployee
    {
        public int PdpId { get; set; }

        [Required]
        public string PdpName { get; set; }

        [DataType(DataType.Date)]
        public DateTime PdpBirthDay { get; set; }

        [EmailAddress]
        public string PdpEmail { get; set; }

        public string PdpPhone { get; set; }

        public decimal PdpSalary { get; set; }

        public bool PdpStatus { get; set; }
    }
}
