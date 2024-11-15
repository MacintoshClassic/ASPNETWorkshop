using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.Models
{
    public class ClientCar
    {
        [Key]
        public Guid ID { get; set; }

        [DisplayName("Client ID")]
        public Guid ClientId { get; set; }

        [DisplayName("Car ID")]
        public Guid CarId { get; set; }
    }
}