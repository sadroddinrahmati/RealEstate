using RealEstate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RealEstate.Core.Domain;

namespace RealEstate.Web.Helpers
{
    public static class SampleDataProvider
    {
        #region ApplyMigrations
        public static void ApplyMigration(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            // apply migration
            context.Database.Migrate();
        }
        #endregion

        #region Seed
        public static void Seed(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            DataSeed(context).GetAwaiter().GetResult();
        }

        #endregion

        #region TestDataSeed
        private static async Task DataSeed(ApplicationDbContext context)
        {
            #region RemoveRange

            context.Owners.RemoveRange(context.Owners);
            context.Estates.RemoveRange(context.Estates);
            await context.SaveChangesAsync();

            #endregion

            #region Owners

            // Owners
            var ownerList = new List<Owner>
            {
                 new Owner { OwnerId = 1, Name = "صدرالدین", LastName = "رحمتی", Mobile = "09181317468" }
             };
            context.Owners.AddRange(ownerList);
            await context.SaveChangesAsync();

            #endregion

            #region Estates

            // Estates
            //var estateList = new List<Estate>
            //{
            //};
            //context.Estates.AddRange(estateList);
            //await context.SaveChangesAsync();

            #endregion
        }
        #endregion
    }
}
