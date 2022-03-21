using FuCoreApp.Core.Models;
using FuCoreApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<Product> GetWithByIdAsync(int productId);
    }
}
