using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class ServiceTicket
    {
        [Key]
        public Guid ID { get; set; }

        [DisplayName("Car ID")]
        public Guid CarId { get; set; }

        [DisplayName("Mechanic ID")]
        public Guid MechanicId { get; set; }

        [DisplayName("Service status ID")]
        public Guid ServiceStatusId { get; set; }

        [DisplayName("Service type ID")]
        public Guid ServiceTypeId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        [DisplayName("Total Price")]
        public float PriceTotal { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Case description")]
        public string CaseDescription { get; set; }
    }
}
