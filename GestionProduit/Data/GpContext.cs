using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Conventions;
using Gp.Domain;

namespace Data
{
    public class GpContext : DbContext
    {
        public GpContext():base("Name=Alias")
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Facture> Factures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTimeConvention());
            modelBuilder.Conventions.Add(new KeyConvetion());
        }

    }
}
