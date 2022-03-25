using FuCoreApp.Core.Models;
using FuCoreApp.Data.Configuration;
using FuCoreApp.Data.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //fluentapi
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] {1,2}));

        }


        //save 
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach(var x in datas)
            {
                if (x.State == EntityState.Added)
                {
                    x.Entity.CreatedBy = 1;
                    x.Entity.CreatedDate= DateTime.Now;

                }
                else if (x.State == EntityState.Modified)
                {
                    x.Entity.UpdatedBy = 1;
                    x.Entity.UpdatedDate= DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var x in datas)
            {
                if (x.State == EntityState.Modified)
                {
                    x.Entity.UpdatedBy = 1;
                    x.Entity.UpdatedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

    }
}
