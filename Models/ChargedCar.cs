using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class ChargedCar
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string LicensePlate { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        public float Kwh { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime dateTime { get; set; }

        public float PriceTotal
        {
            get
            {
                return (float)(Kwh * 0.7);
            }
            // I want to keep the setter but prevent external changes, so I marked it as privat:
            // private set { }

            // but I don't need setter here at all becaucse I need PriceTotal to be the read-only property
            // If I remove set {} -> the PriceTotal column will not show up in the database
            set { }
        }
    }
}