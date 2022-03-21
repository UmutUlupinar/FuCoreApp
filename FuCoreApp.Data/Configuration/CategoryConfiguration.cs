using FuCoreApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> //configuraiton sınıfı oluşturdu
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.ID).UseIdentityColumn();
            builder.Property(s=>s.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
        }
    }
}
