using System;
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
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
