using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BBSolarOMS.Entities
{
    public class BBSolarOMSContext:DbContext
    {
        public BBSolarOMSContext(DbContextOptions<BBSolarOMSContext> options):base(options)
        {
            Database.Migrate();
        }

        public DbSet<Installers> Installers { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
