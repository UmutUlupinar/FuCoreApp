using FuCoreApp.Core.Repository;
using FuCoreApp.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FuCoreApp.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repo;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _repo.Where(predicate);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
           return await _repo.SingleOrDefaultAsync(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
           await _repo.AddAsync(entity);
           await _unitOfWork.CommitAsync();
           return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repo.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;

        }


        public T Update(T entity)
        {
            T upd = _repo.Update(entity);
            _unitOfWork.CommitAsync();
            return upd;
        }


        public void Remove(T entity)
        {
            _repo.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repo.RemoveRange(entities);
            _unitOfWork.Commit();
        }

      


       
    }
}
