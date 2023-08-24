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
    public class TourGuideManager : ITourGuideService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TourGuideManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TourGuide> AddAsync(TourGuide Entity)
        {
            await _unitOfWork.TourGuideRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<TourGuide>> GetAllAsync(Expression<Func<TourGuide, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.TourGuideRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<TourGuide> GetAsync(Expression<Func<TourGuide, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.TourGuideRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(TourGuide Entity)
        {
            await _unitOfWork.TourGuideRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(TourGuide Entity)
        {
            await _unitOfWork.TourGuideRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
