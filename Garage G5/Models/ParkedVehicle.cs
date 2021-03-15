﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage_G5.Models
{
    public class ParkedVehicle
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Type")]
        public VehicleType? VehicleType { get; set; }
        [Display(Name = "Registration")]
        [Remote("IsRegisterNumberExists", "ParkedVehicles", ErrorMessage = "Registration Number already in use", AdditionalFields = "Id")]
        public string RegistrationNum { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
        [Display(Name = "Wheels")]
        public int WheelsNum { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnteringTime
        {
            get;set;

        }

        [NotMapped]
        public IEnumerable<SelectListItem> GetVehiclesType { get; set; }

    }
}
