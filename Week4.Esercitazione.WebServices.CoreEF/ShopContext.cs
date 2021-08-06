using Microsoft.EntityFrameworkCore;
using System;
using Week4.Esercitazione.WebServices.CoreEF.Configuration;
using Week4.EsercitazioneWebServices.Core.Models;

namespace Week4.Esercitazione.WebServices.CoreEF
{
    public class ShopContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopContext() :base() { }

        public ShopContext(DbContextOptions<ShopContext> options)
           : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //(@"Persist Security Info = False; Integrated Security = true; 
                //Initial Catalog = AgenziaViaggi3; Server = .\SQLEXPRESS")
                options.UseSqlServer(@"Persist Security Info = False; Integrated Security = true;
                Initial Catalog = ShopWCF; Server = .\SQLEXPRESS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }


    }
}
