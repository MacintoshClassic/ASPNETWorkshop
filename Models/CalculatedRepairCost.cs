using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class CalculatedRepairCost
    {
        [Key]
        public Guid ID { get; set; }

        // based on ID from ServiceTicket table
        [Required]
        public Guid ServiceTicketId { get; set; }

        // based on ID from CarPart table
        [Required]
        public Guid CarPartId { get; set; }

        [Required]
        public int CarPartQuantity { get; set; }

        [Required]
        public int HoursDedicated { get; set; }

        public float PriceTotal
        {
            get
            {
                // (PricePerUnit from CarPart table x Quantity from input) + (HourlyRate from MechanicId table x HoursDedicated from input)
                return (float)(CarPartQuantity * 40);
            }
            set { }
        }
    }
}