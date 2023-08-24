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
    public class TourManager : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TourManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tour> AddAsync(Tour Entity)
        {
            await _unitOfWork.TourRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Tour>> GetAllAsync(Expression<Func<Tour, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.TourRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<Tour> GetAsync(Expression<Func<Tour, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.TourRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(Tour Entity)
        {
            await _unitOfWork.TourRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(Tour Entity)
        {
            await _unitOfWork.TourRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
