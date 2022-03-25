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
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repo) : base(unitOfWork, repo)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await _unitOfWork.category.GetWithProductByIdAsync(categoryId);
        }
    }
}
