using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Core.Models
{
    public class Category:BaseEntity
    {
        public Category()
        {
           // Products = new Collection<Product>();
        }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; } =
            new Collection<Product>();






    }
}
