using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class OrderStatus
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Enums.OrderStatusEnum OrderStatusName { get; set; }

        // value can be added only if value >= 0
        [Range(0, int.MaxValue, ErrorMessage = "Value must be a positive number")]
        public int QuantityOrdered { get; set; }
    }
}
