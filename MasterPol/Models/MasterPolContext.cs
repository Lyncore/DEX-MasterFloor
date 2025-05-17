using System.Globalization;
using System.IO;
using CsvHelper;
using Microsoft.EntityFrameworkCore;

namespace MasterPol.Models
{
    internal class MasterPolContext : DbContext
    {
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<History> History { get; set; }

        public MasterPolContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.10.151;Initial Catalog=wsr1_dex_demo;User ID=wsr-1;Password=\"$cYm*kL$Ny5QP#\";Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            using var ptReader = new StreamReader("Import/Product_type_import.csv");

            List<ProductType> pt = [];

            while (!ptReader.EndOfStream)
            {
                string? line = ptReader.ReadLine();

                if (line == null) continue;

                string[] cells = line.Split(';');

                pt.Add(new ProductType { 
                    Id = Convert.ToInt32(cells[0]),
                    Name = cells[1],
                    Coefficient = Convert.ToDecimal(cells[2]),
                });
            }

            modelBuilder.Entity<ProductType>().HasData(pt);
        }
    }
}
