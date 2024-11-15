using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Models
{
    public class RefueledCar
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        [DisplayName("License plate")]
        public string LicensePlate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "0 is a minimal value")]
        public float Litres { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DisplayName("Date and time")]
        public DateTime dateTime { get; set; }

        [DisplayName("Total price")]
        public float PriceTotal
        {
            get
            {
                return (float)(Litres * 1.4);
            }
            // If I remove set {} -> the PriceTotal column will not show up in the database
            set { }
        }
    }
}