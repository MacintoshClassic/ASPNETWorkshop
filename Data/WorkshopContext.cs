using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workshop.Models;

namespace Workshop.Data
{
    public class WorkshopContext : DbContext
    {
        public WorkshopContext (DbContextOptions<WorkshopContext> options)
            : base(options)
        {
        }

        public DbSet<Workshop.Models.Client> Client { get; set; } = default!;
        public DbSet<Workshop.Models.Car> Car { get; set; } = default!;
        public DbSet<Workshop.Models.ClientCar> ClientCar { get; set; } = default!;
        public DbSet<Workshop.Models.CarPart> CarPart { get; set; } = default!;
        public DbSet<Workshop.Models.OrderStatus> OrderStatus { get; set; } = default!;
        public DbSet<Workshop.Models.ServiceTicket> ServiceTicket { get; set; } = default!;
        public DbSet<Workshop.Models.Mechanic> Mechanic { get; set; } = default!;
        public DbSet<Workshop.Models.ServiceType> ServiceType { get; set; } = default!;
        public DbSet<Workshop.Models.ServiceStatus> ServiceStatus { get; set; } = default!;
        public DbSet<Workshop.Models.RefueledCar> RefueledCar { get; set; } = default!;
        public DbSet<Workshop.Models.ChargedCar> ChargedCar { get; set; } = default!;
        public DbSet<Workshop.Models.CalculatedRepairCost> CalculatedRepairCost { get; set; } = default!;
    }
}
