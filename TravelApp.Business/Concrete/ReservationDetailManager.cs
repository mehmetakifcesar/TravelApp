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
    public class ReservationDetailManager : IReservationDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationDetailManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReservationDetail> AddAsync(ReservationDetail Entity)
        {
            await _unitOfWork.ReservationDetailRepository.AddAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<ReservationDetail>> GetAllAsync(Expression<Func<ReservationDetail, bool>> filter, params string[] IncludeProperties)
        {
           return await _unitOfWork.ReservationDetailRepository.GetAllAsync(filter, IncludeProperties);
        }

        public Task<ReservationDetail> GetAsync(Expression<Func<ReservationDetail, bool>> filter, params string[] IncludeProperties)
        {
            return _unitOfWork.ReservationDetailRepository.GetAsync(filter, IncludeProperties);
        }

        public async Task RemoveAsync(ReservationDetail Entity)
        {
            await _unitOfWork.ReservationDetailRepository.RemoveAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateAsync(ReservationDetail Entity)
        {
            await _unitOfWork.ReservationDetailRepository.UpdateAsync(Entity);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
