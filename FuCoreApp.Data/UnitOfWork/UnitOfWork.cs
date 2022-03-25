using FuCoreApp.Core.Repository;
using FuCoreApp.Core.UnitOfWork;
using FuCoreApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public IProductRepository product => _productRepository??=
                     new ProductRepository(_db);

        public ICategoryRepository category => _categoryRepository ??=
                     new CategoryRepository(_db);

        public void Commit()
        {
            _db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
