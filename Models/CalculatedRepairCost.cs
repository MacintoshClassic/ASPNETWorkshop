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
                // (Quantity from input * PricePerUnit from CarPart table) + (HoursDedicated from input * HourlyRate from MechanicId table)
                return (CarPartQuantity * 40) + (HoursDedicated * 100);
            }
            set { }
        }
    }
}