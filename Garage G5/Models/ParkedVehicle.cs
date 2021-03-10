using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_G5.Models
{
    public class ParkedVehicle
    {
        private DateTime? dateCreated;

        public int Id { get; set; }

        public VehicleType VehicleType { get; set; }

        public string RegistrationNum { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int WheelsNum { get; set; }

       
        [Display(Name = "Date Created")]
        public DateTime EnteringTime { get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
        }

    }
}
