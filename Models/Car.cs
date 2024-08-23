using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.Models
{
    public class Car
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Make { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Model { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4)")]
        public int Year { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string LicensePlate { get; set; }
    }
}