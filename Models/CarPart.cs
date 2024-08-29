using System;
using System.ComponentModel;
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
        [DisplayName("Car part name")]
        public string CarPartName { get; set; }

        [DisplayName("Car ID")]
        public Guid? CarId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        [DisplayName("Quantity available")]
        public int QuantityAvailable { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        [DisplayName("Price per unit")]
        public float PricePerUnit { get; set; }

        [DisplayName("Order status ID")]
        public Guid OrderStatusId { get; set; }
    }
}
