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
    }
}
