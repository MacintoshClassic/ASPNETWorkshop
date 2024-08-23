using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class CarPart
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CarPartName { get; set; }

        public Guid CarId { get; set; }
        public int QuantityAvailable { get; set; }
        public float PricePerUnit { get; set; }
        public Guid OrderStatusId { get; set; }
    }
}
