
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Business.Abstract;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Abstract.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.Business.Concrete
{
    public class DestinationManager : IDestinationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DestinationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Destination> AddAsync(Destination Entity)
        {
            await _unitOfWork.DestinationRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public Task<IEnumerable<Destination>> GetAllAsync(Expression<Func<Destination, bool>> filter, params string[] IncludeProperties)
        {
            return _unitOfWork.DestinationRepository.GetAllAsync(filter, IncludeProperties);
        }

        public Task<Destination> GetAsync(Expression<Func<Destination, bool>> filter, params string[] IncludeProperties)
        {
            return _unitOfWork.DestinationRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(Destination Entity)
        {
            await _unitOfWork.DestinationRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(Destination Entity)
        {
            await _unitOfWork.DestinationRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
