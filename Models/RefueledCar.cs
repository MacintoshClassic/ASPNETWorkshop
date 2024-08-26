using System;
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
        public string LicensePlate { get; set; }

        public float Litres { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime dateTime { get; set; }

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