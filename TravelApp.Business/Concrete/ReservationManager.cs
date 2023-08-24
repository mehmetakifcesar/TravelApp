using Microsoft.EntityFrameworkCore.Metadata;
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
    public class ReservationManager : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation> AddAsync(Reservation Entity)
        {
            await _unitOfWork.ReservationRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync(Expression<Func<Reservation, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.ReservationRepository.GetAllAsync(filter, IncludeProperties);
        }

        public async Task<Reservation> GetAsync(Expression<Func<Reservation, bool>> filter, params string[] IncludeProperties)
        {
            return await _unitOfWork.ReservationRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(Reservation Entity)
        {
            await _unitOfWork.ReservationRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(Reservation Entity)
        {
            await _unitOfWork.ReservationRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
