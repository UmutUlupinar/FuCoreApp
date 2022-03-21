using FuCoreApp.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Core.UnitOfWork
{
    public interface IUnitOfWork            //saveChanges işlemi buraada yapılır
    {
        IProductRepository product { get; }
        ICategoryRepository category { get; }
        Task CommitAsync();                 
        void Commit();


    }
}
