using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.EFRepository
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private DbSet<TEntity> _entities;

        #endregion

        #region Constructor

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        #endregion

        #region Methods

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsNoTracking();
        }

        public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, 
            params Expression<Func<TEntity, object>>[] includes)
        {  
            var result = _entities.AsQueryable();
            
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            if (predicate != null)
            {
                result = _entities.Where(predicate);
            }
            return await result.ToListAsync();
        }
        public TEntity FindByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities
                .AsNoTracking()
                .SingleOrDefault(predicate);
        }



        public TEntity FindById(Guid id)
        {
            throw new NotImplementedException();
        }
        public TEntity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _entities.Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _entities.Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }



        #endregion
    }
}
