using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Business.Concrete;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Abstract;
using TravelApp.Entity.DTO.Tour;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[action]")]
    public class TourController : Controller
    {
       private readonly ITourService _tourService;
        private readonly IMapper _mapper;
        public TourController(ITourService tourService, IMapper mapper)
        {
            _tourService = tourService;
            _mapper = mapper;
        }
        [HttpPost("/AddTour")]
        [ProducesResponseType(typeof(ErrorResult<TourDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddTour(TourDTORequest tourDTORequest)
        {

            TourValidator tourValidator = new();

            if (tourValidator.Validate(tourDTORequest).IsValid)
            {
                Tour tour = _mapper.Map<Tour>(tourDTORequest);

                await _tourService.AddAsync(tour);

                TourDTOResponse tourDTOResponse = _mapper.Map<TourDTOResponse>(tour);
                return Ok(ErrorResult<TourDTOResponse>.SuccessWithData(tourDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < tourValidator.Validate(tourDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(tourValidator.Validate(tourDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/Tour")]
        [ProducesResponseType(typeof(ErrorResult<List<TourDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTours()
        {
            var tours = await _tourService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (tours != null)
            {
                List<TourDTOResponse> tourDtoResponse = new List<TourDTOResponse>();

                foreach (var tour in tours)
                {
                    tourDtoResponse.Add(_mapper.Map<TourDTOResponse>(tour));
                }

                return Ok(ErrorResult<List<TourDTOResponse>>.SuccessWithData(tourDtoResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<TourDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/Tour/{tourGUID}")]
        [ProducesResponseType(typeof(ErrorResult<TourDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTourByGUID(Guid tourGUID)
        {
            var tour = await _tourService.GetAsync(q => q.GUID == tourGUID);

            if (tour != null)
            {
                TourDTOResponse tourDTOResponse = _mapper.Map<TourDTOResponse>(tour);

                return Ok(ErrorResult<TourDTOResponse>.SuccessWithData(tourDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<TourDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateTour")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTour(TourUpdateDTORequest tourUpdateDTORequest)
        {
            Tour tour = await _tourService.GetAsync(q => q.GUID == tourUpdateDTORequest.Guid);


            tour.Name = tourUpdateDTORequest.Name;
            tour.Description = tourUpdateDTORequest.Description;
            tour.Price = tourUpdateDTORequest.Price;
            tour.StartingDate = tourUpdateDTORequest.StartingDate;
            tour.EndingDate = tourUpdateDTORequest.EndingDate;
            tour.IsActive = tourUpdateDTORequest.IsActive != null ? tourUpdateDTORequest.IsActive : tour.IsActive;

            await _tourService.UpdateAsync(tour);

            return Ok(ErrorResult<TourDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveTour/{tourGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveTour(Guid tourGUID)
        {

            Tour tour = await _tourService.GetAsync(q => q.GUID == tourGUID);

            tour.IsActive = false;
            tour.IsDeleted = true;

            await _tourService.UpdateAsync(tour);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
