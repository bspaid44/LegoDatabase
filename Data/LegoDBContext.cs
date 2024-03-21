using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Data
{
    internal class LegoDBContext : DbContext
    {
        public DbSet<Models.Inventory> Inventories { get; set; }
        public DbSet<Models.InventoryPart> InventoryParts { get; set; }
        public DbSet<Models.Part> Parts { get; set; }
        public DbSet<Models.PartCategory> PartCategories { get; set; }
        public DbSet<Models.Set> Sets { get; set; }
        public DbSet<Models.Theme> Themes { get; set; }
        public DbSet<Models.Color> Colors { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LegoDB;Trusted_Connection=True;");
        }
    }
}
