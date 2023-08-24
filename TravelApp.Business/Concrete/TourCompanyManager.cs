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
    public class TourCompanyManager : ITourCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TourCompanyManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TourCompany> AddAsync(TourCompany Entity)
        {
            await _unitOfWork.TourCompanyRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<TourCompany>> GetAllAsync(Expression<Func<TourCompany, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.TourCompanyRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<TourCompany> GetAsync(Expression<Func<TourCompany, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.TourCompanyRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(TourCompany Entity)
        {
            await _unitOfWork.TourCompanyRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(TourCompany Entity)
        {
            await _unitOfWork.TourCompanyRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
