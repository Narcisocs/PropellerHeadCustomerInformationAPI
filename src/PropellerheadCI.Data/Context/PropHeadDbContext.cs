using Microsoft.EntityFrameworkCore;
using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropellerheadCI.Data.Context
{
    public class PropHeadDbContext : DbContext
    {
        public PropHeadDbContext()
        {

        }

        public PropHeadDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PropHeadDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
