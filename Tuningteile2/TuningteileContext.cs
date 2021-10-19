using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuningteile2.Model;

namespace Tuningteile2
{
    class TuningteileContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {

            dbContextOptionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Tuningteile2");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Modell> Modells { get; set; }
        public DbSet<Tuningpart> Tuningparts { get; set; }
        public DbSet<ModellTuningpart> ModellTuningparts { get; set; }
    }
}
