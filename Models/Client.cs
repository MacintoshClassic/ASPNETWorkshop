using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class Client
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Full name")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(15)")]
        [Phone]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
    }
}
