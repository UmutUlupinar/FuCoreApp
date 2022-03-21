﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Core.Models
{
    public class Product:BaseEntity
    {       
        public string Name { get; set; }
        public int Stock { get; set; }

        public decimal Price { get; set; }

        //foreignKey
        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public string InnerBarcode { get; set; }

        public Category Category { get; set; }

    }
}
