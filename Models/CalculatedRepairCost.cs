using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class CalculatedRepairCost
    {
        [Key]
        public Guid ID { get; set; }

        // based on ID from Mechanic table
        [Required]
        public Guid Mechanicid { get; set; }

        // based on ID from CarPart table
        [Required]
        public Guid CarPartId { get; set; }

        [Required]
        public int CarPartQuantity { get; set; }

        [Required]
        public int HoursDedicated { get; set; }

        public float PriceTotal { get; set; }
    }
}