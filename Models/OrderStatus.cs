using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class OrderStatus
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [DisplayName("Order status name")]
        public Enums.OrderStatusEnum OrderStatusName { get; set; }

        // based on ID from CarPart table
        [Required]
        [DisplayName("Car part ID")]
        public Guid CarPartId { get; set; }

        // value can be added only if value >= 0
        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        [DisplayName("Quantity ordered")]
        public int QuantityOrdered { get; set; }

        [DisplayName("Total price")]
        public float PriceTotal { get; set; }
    }
}
