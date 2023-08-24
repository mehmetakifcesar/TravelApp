using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.DAL.Abstract.DataManagement
{
    public interface IRepository<T> where T : AuditableEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] IncludeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, params string[] IncludeProperties);
        Task<EntityEntry<T>> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);
    }
}
