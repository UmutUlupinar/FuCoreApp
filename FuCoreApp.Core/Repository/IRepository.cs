using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Core.Repository
{
    public interface IRepository<T> where T : class
    {

        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);//(s=>s.Id==5)

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);    //Toplu ekleme

        T Update(T entity);
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);



    }
}
