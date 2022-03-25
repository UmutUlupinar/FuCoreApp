using FuCoreApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Data.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                ID = 1,
                Name = "dolma kalem",
                Price = 125.75m,
                Stock = 100,
                CategoryId = _ids[0],
                CreatedBy=1,
                CreatedDate = DateTime.Now,
                InnerBarcode = "",
                IsDeleted = false
            },
            new Product{
                ID = 2,
                Name = "Tukenmez kalem",
                Price = 55.75m,
                Stock = 100,
                CategoryId = _ids[0],
                CreatedBy=1,
                CreatedDate = DateTime.Now,
                InnerBarcode = "",
                IsDeleted = false
            }, 
            new Product{
                ID = 3,
                Name = "Kurşun kalem",
                Price = 77.75m,
                Stock = 100,
                CategoryId = _ids[0],
                CreatedBy=1,
                CreatedDate = DateTime.Now,
                InnerBarcode = "",
                IsDeleted = false
            }, 
            new Product{
                ID = 4,
                Name = "kareli Defter",
                Price = 55.75m,
                Stock = 100,
                CategoryId = _ids[1],
                CreatedBy=1,
                CreatedDate = DateTime.Now,
                InnerBarcode = "",
                IsDeleted = false
            }, 
            new Product{
                ID = 5,
                Name = "defter",
                Price = 55.75m,
                Stock = 100,
                CategoryId = _ids[1],
                CreatedBy=1,
                CreatedDate = DateTime.Now,
                InnerBarcode = "",
                IsDeleted = false
            }, 
            new Product{
                ID = 6,
                Name = "amel defteri",
                Price = 85.75m,
                Stock = 100,
                CategoryId = _ids[1],
                CreatedBy=1,
                CreatedDate = DateTime.Now,
                InnerBarcode ="",IsDeleted=false
            }
            
            );
        }
    }
}
