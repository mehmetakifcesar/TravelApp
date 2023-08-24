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
    public class HotelManager : IHotelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Hotel> AddAsync(Hotel Entity)
        {
           await _unitOfWork.HotelRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync(Expression<Func<Hotel, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.HotelRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<Hotel> GetAsync(Expression<Func<Hotel, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.HotelRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(Hotel Entity)
        {
            await _unitOfWork.HotelRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(Hotel Entity)
        {
            await _unitOfWork.HotelRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
