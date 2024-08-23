using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class ServiceTicket
    {
        [Key]
        public Guid ID { get; set; }
        public Guid CarId { get; set; }
        public Guid MechanicId { get; set; }
        public Guid ServiceStatusId { get; set; }
        public Guid ServiceTypeId { get; set; }
        public float PriceTotal { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CaseDescription { get; set; }
    }
}
