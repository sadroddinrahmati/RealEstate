using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.EFRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null,  
            params Expression<Func<TEntity, object>>[] includes);
        TEntity FindByExpression(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(Guid id);
        TEntity FindById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity); 
        void Delete(TEntity entity); 
        void SaveChanges();
    }
}
