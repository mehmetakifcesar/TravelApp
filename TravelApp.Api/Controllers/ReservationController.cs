using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Concrete;
using TravelApp.Business.Abstract;
using TravelApp.Entity.DTO.Reservation;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[action]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }
        [HttpPost("/AddReservation")]
        [ProducesResponseType(typeof(ErrorResult<ReservationDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddReservation(ReservationDTORequest reservationDTORequest)
        {

            ReservationValidator reservationValidator = new();

            if (reservationValidator.Validate(reservationDTORequest).IsValid)
            {
                Reservation reservation = _mapper.Map<Reservation>(reservationDTORequest);

                await _reservationService.AddAsync(reservation);

                ReservationDTOResponse reservationDTOResponse = _mapper.Map<ReservationDTOResponse>(reservation);
                return Ok(ErrorResult<ReservationDTOResponse>.SuccessWithData(reservationDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < reservationValidator.Validate(reservationDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(reservationValidator.Validate(reservationDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/Reservation")]
        [ProducesResponseType(typeof(ErrorResult<List<ReservationDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _reservationService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (reservations != null)
            {
                List<ReservationDTOResponse> ReservationDTOResponse = new List<ReservationDTOResponse>();

                foreach (var reservation in reservations)
                {
                    ReservationDTOResponse.Add(_mapper.Map<ReservationDTOResponse>(reservation));
                }

                return Ok(ErrorResult<List<ReservationDTOResponse>>.SuccessWithData(ReservationDTOResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<ReservationDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/Reservation/{reservationGUID}")]
        [ProducesResponseType(typeof(ErrorResult<ReservationDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetReservationByGUID(Guid reservationGUID)
        {
            var reservation = await _reservationService.GetAsync(q => q.GUID == reservationGUID);

            if (reservation != null)
            {
                ReservationDTOResponse reservationDTOResponse = _mapper.Map<ReservationDTOResponse>(reservation);

                return Ok(ErrorResult<ReservationDTOResponse>.SuccessWithData(reservationDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<ReservationDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateReservation")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateReservation(ReservationUpdateDTORequest reservationUpdateDTORequest)
        {
            Reservation reservation = await _reservationService.GetAsync(q => q.GUID == reservationUpdateDTORequest.Guid);

            reservation.ReservationDate = reservationUpdateDTORequest.ReservationDate;
            reservation.NumberOfTravelers = reservationUpdateDTORequest.NumberOfTravelers;
            reservation.UserID = reservationUpdateDTORequest.UserID;
            reservation.Price = reservationUpdateDTORequest.Price;


            reservation.IsActive = reservationUpdateDTORequest.IsActive != null ? reservationUpdateDTORequest.IsActive : reservation.IsActive;

            await _reservationService.UpdateAsync(reservation);

            return Ok(ErrorResult<ReservationDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveReservation/{reservationGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveReservation(Guid ReservationGUID)
        {

            Reservation reservation = await _reservationService.GetAsync(q => q.GUID == ReservationGUID);

            reservation.IsActive = false;
            reservation.IsDeleted = true;

            await _reservationService.UpdateAsync(reservation);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
