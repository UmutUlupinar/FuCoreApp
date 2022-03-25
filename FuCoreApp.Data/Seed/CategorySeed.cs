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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;
        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                ID = _ids[0],
                Name = "Kalemler",
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                IsDeleted = false
            },
            new Category{
                ID = _ids[1],
                Name = "Defterler",
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                IsDeleted = false
            }

             );
        }
    }
}
