using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DAL.Abstract.DataManagement;
using TravelApp.Entity.Base;

namespace TravelApp.DAL.Concrete.EntityFramework.DataManagement
{
    public class EFRepository<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<EntityEntry<T>> AddAsync(T Entity)
        {
            return await _dbSet.AddAsync(Entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (IncludeProperties != null)
            {
                foreach (var item in IncludeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await Task.Run(() => query);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if (IncludeProperties.Length > 0)
            {
                foreach (var item in IncludeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task RemoveAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Remove(Entity));
        }

        public async Task UpdateAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Update(Entity));

        }
    }
}