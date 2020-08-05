using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RealEstate.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estate> Estates { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 

            builder.Entity<Estate>().ToTable("Estate");
            builder.Entity<Owner>().ToTable("Owner");

            builder.Entity<Estate>()
              .HasQueryFilter(u => !u.IsDelete);


            builder.Entity<Owner>()
               .HasData(
                   new Owner { OwnerId = 1, Name = "صدرالدین", LastName = "رحمتی", Mobile = "09481317468" } 
               );
        }
    }
    public class MyContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RealEstateDB;Integrated Security=True;MultipleActiveResultSets=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
