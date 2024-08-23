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

        public int QuantityOrdered { get; set; }
    }
}
