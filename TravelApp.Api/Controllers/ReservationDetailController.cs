using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Concrete;
using TravelApp.Business.Abstract;
using TravelApp.Entity.DTO.ReservationDetail;
using TravelApp.Entity.DTO;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[action]")]
    public class ReservationDetailController : Controller
    {
        private readonly IReservationDetailService _reservationDetailService;
        private readonly IMapper _mapper;
        public ReservationDetailController(IReservationDetailService reservationDetailService, IMapper mapper)
        {
            _reservationDetailService = reservationDetailService;
            _mapper = mapper;
        }
        [HttpPost("/AddReservationDetail")]
        [ProducesResponseType(typeof(ErrorResult<ReservationDetailDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddReservationDetail(ReservationDetailDTORequest reservationDetailDTORequest)
        {

            ReservationDetailValidator reservationDetailValidator = new();

            if (reservationDetailValidator.Validate(reservationDetailDTORequest).IsValid)
            {
                ReservationDetail reservationDetail = _mapper.Map<ReservationDetail>(reservationDetailDTORequest);

                await _reservationDetailService.AddAsync(reservationDetail);

                ReservationDetailDTOResponse reservationDetailDTOResponse = _mapper.Map<ReservationDetailDTOResponse>(reservationDetail);
                return Ok(ErrorResult<ReservationDetailDTOResponse>.SuccessWithData(reservationDetailDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < reservationDetailValidator.Validate(reservationDetailDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(reservationDetailValidator.Validate(reservationDetailDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/ReservationDetail")]
        [ProducesResponseType(typeof(ErrorResult<List<ReservationDetailDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetReservationDetails()
        {
            var reservationDetails = await _reservationDetailService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (reservationDetails != null)
            {
                List<ReservationDetailDTOResponse> reservationDetailDTOResponse = new List<ReservationDetailDTOResponse>();

                foreach (var reservationDetail in reservationDetails)
                {
                    reservationDetailDTOResponse.Add(_mapper.Map<ReservationDetailDTOResponse>(reservationDetail));
                }

                return Ok(ErrorResult<List<ReservationDetailDTOResponse>>.SuccessWithData(reservationDetailDTOResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<ReservationDetailDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/ReservationDetail/{reservationDetailGUID}")]
        [ProducesResponseType(typeof(ErrorResult<ReservationDetailDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetReservationDetailByGUID(Guid reservationDetailGUID)
        {
            var reservationDetail = await _reservationDetailService.GetAsync(q => q.GUID == reservationDetailGUID);

            if (reservationDetail != null)
            {
                ReservationDetailDTOResponse reservationDetailDTOResponse = _mapper.Map<ReservationDetailDTOResponse>(reservationDetail);

                return Ok(ErrorResult<ReservationDetailDTOResponse>.SuccessWithData(reservationDetailDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<ReservationDetailDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateReservationDetail")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateReservationDetail(ReservationDetailUpdateDTORequest reservationDetailUpdateDTORequest)
        {
            ReservationDetail reservationDetail = await _reservationDetailService.GetAsync(q => q.GUID == reservationDetailUpdateDTORequest.Guid);

            reservationDetail.DateTime = reservationDetailUpdateDTORequest.DateTime;
            reservationDetail.ReservationID = reservationDetailUpdateDTORequest.ReservationID;
            reservationDetail.TotalPrice = reservationDetailUpdateDTORequest.TotalPrice;


            reservationDetail.IsActive = reservationDetailUpdateDTORequest.IsActive != null ? reservationDetailUpdateDTORequest.IsActive : reservationDetail.IsActive;

            await _reservationDetailService.UpdateAsync(reservationDetail);

            return Ok(ErrorResult<ReservationDetailDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveReservationDetail/{reservationDetailGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveReservationDetail(Guid reservationDetailGUID)
        {

            ReservationDetail reservationDetail = await _reservationDetailService.GetAsync(q => q.GUID == reservationDetailGUID);

            reservationDetail.IsActive = false;
            reservationDetail.IsDeleted = true;

            await _reservationDetailService.UpdateAsync(reservationDetail);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
