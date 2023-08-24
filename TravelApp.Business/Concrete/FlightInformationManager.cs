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
    public class FlightInformationManager : IFlightInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightInformationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FlightInformation> AddAsync(FlightInformation Entity)
        {
            await _unitOfWork.FlightInformationRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<FlightInformation>> GetAllAsync(Expression<Func<FlightInformation, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.FlightInformationRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<FlightInformation> GetAsync(Expression<Func<FlightInformation, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.FlightInformationRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(FlightInformation Entity)
        {
            await _unitOfWork.FlightInformationRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(FlightInformation Entity)
        {
            await _unitOfWork.FlightInformationRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
