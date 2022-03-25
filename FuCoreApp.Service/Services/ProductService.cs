using FuCoreApp.Core.Models;
using FuCoreApp.Core.Repository;
using FuCoreApp.Core.Services;
using FuCoreApp.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repo) : base(unitOfWork, repo)
        {
        }

        public async Task<Product> GetWithByIdAsync(int productId)
        {
            return await _unitOfWork.product.GetWithByIdAsync(productId);
        }
    }
}
