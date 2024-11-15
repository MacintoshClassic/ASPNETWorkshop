using System;
using System.ComponentModel;
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
        [DisplayName("Mechanic ID")]
        public Guid MechanicId { get; set; }

        // based on ID from CarPart table
        [Required]
        [DisplayName("Car part ID")]
        public Guid CarPartId { get; set; }

        [Required]
        [DisplayName("Car part quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        public int CarPartQuantity { get; set; }

        [Required]
        [DisplayName("Hours dedicated")]
        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        public int HoursDedicated { get; set; }

        [DisplayName("Price total")]
        public float PriceTotal { get; set; }
    }
}