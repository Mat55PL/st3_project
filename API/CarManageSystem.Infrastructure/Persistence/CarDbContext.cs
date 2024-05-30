using CarManageSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManageSystem.Infrastructure.Persistence
{
    internal class CarDbContext(DbContextOptions<CarDbContext> options) : DbContext(options)
    {
        internal DbSet<Car> Cars { get; set; }
        internal DbSet<CarInfo> CarsInfo { get; set; }
        internal DbSet<FuelHistory> FuelHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
