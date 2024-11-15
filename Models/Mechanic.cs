using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class Mechanic
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Full name")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(15)")]
        [Phone]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        [DisplayName("Hourly rate")]
        public float HourlyRate { get; set; }



    }
}
