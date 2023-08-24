using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Business.Abstract;
using TravelApp.DAL.Abstract.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AddAsync(User Entity)
        {
            await _unitOfWork.UserRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> filter, params string[] IncludeProperties)
        {
          return await _unitOfWork.UserRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.UserRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(User Entity)
        {
            await _unitOfWork.UserRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(User Entity)
        {
            await _unitOfWork.UserRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
