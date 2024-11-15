using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class ServiceStatus
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Service status name")]
        public string ServiceStatusName { get; set; }
    }
}
