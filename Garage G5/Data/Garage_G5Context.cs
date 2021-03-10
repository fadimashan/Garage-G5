using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_G5.Models;

namespace Garage_G5.Data
{
    public class Garage_G5Context : DbContext
    {
        public Garage_G5Context (DbContextOptions<Garage_G5Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_G5.Models.ParkedVehicle> ParkedVehicle { get; set; }
    }
}
