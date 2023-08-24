using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Abstract;
using TravelApp.Entity.DTO.Hotel;
using TravelApp.Business.Concrete;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[action]")]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }
        [HttpPost("/AddHotel")]
        [ProducesResponseType(typeof(ErrorResult<HotelDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddHotel(HotelDTORequest hotelDTORequest)
        {

            HotelValidator hotelValidator = new();

            if (hotelValidator.Validate(hotelDTORequest).IsValid)
            {
                Hotel hotel = _mapper.Map<Hotel>(hotelDTORequest);

                await _hotelService.AddAsync(hotel);

                HotelDTOResponse hotelDTOResponse = _mapper.Map<HotelDTOResponse>(hotel);
                return Ok(ErrorResult<HotelDTOResponse>.SuccessWithData(hotelDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < hotelValidator.Validate(hotelDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(hotelValidator.Validate(hotelDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/Hotel")]
        [ProducesResponseType(typeof(ErrorResult<List<HotelDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (hotels != null)
            {
                List<HotelDTOResponse> hotelDTOResponse = new List<HotelDTOResponse>();

                foreach (var Hotel in hotels)
                {
                    hotelDTOResponse.Add(_mapper.Map<HotelDTOResponse>(Hotel));
                }

                return Ok(ErrorResult<List<HotelDTOResponse>>.SuccessWithData(hotelDTOResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<HotelDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/Hotel/{hotelGUID}")]
        [ProducesResponseType(typeof(ErrorResult<HotelDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHotelByGUID(Guid hotelGUID)
        {
            var hotel = await _hotelService.GetAsync(q => q.GUID == hotelGUID);

            if (hotel != null)
            {
                HotelDTOResponse hotelDTOResponse = _mapper.Map<HotelDTOResponse>(hotel);

                return Ok(ErrorResult<HotelDTOResponse>.SuccessWithData(hotelDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<HotelDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateHotel")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateHotel(HotelUpdateDTORequest hotelUpdateDTORequest)
        {
            Hotel hotel = await _hotelService.GetAsync(q => q.GUID == hotelUpdateDTORequest.Guid);

            hotel.Name = hotelUpdateDTORequest.Name;
            hotel.Adress = hotelUpdateDTORequest.Adress;
            hotel.NumberOfTravelers = hotelUpdateDTORequest.NumberOfTravelers;
            hotel.RoomNumber = hotelUpdateDTORequest.RoomNumber;
            hotel.ReservationDate = hotelUpdateDTORequest.ReservationDate;
            hotel.Country = hotelUpdateDTORequest.Country;
            hotel.City = hotelUpdateDTORequest.City;
            hotel.Price = hotelUpdateDTORequest.Price;


            hotel.IsActive = hotelUpdateDTORequest.IsActive != null ? hotelUpdateDTORequest.IsActive : hotel.IsActive;

            await _hotelService.UpdateAsync(hotel);

            return Ok(ErrorResult<HotelDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveHotel/{hotelGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveHotel(Guid hotelGUID)
        {

            Hotel hotel = await _hotelService.GetAsync(q => q.GUID == hotelGUID);

            hotel.IsActive = false;
            hotel.IsDeleted = true;

            await _hotelService.UpdateAsync(hotel);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
