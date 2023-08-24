using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Business.Concrete;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Abstract;
using TravelApp.Entity.DTO.TourGuide;
using TravelApp.Entity.DTO;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravaelApp/[action]")]
    public class TourGuideController : Controller
    {
       private readonly ITourGuideService _tourGuideService;
        private readonly IMapper _mapper;
        public TourGuideController(ITourGuideService tourGuideService, IMapper mapper)
        {
            _tourGuideService = tourGuideService;
            _mapper = mapper;
        }

        [HttpPost("/AddTourGuide")]
        [ProducesResponseType(typeof(ErrorResult<TourGuideDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddTourGuide(TourGuideDTORequest tourGuideDTORequest)
        {

            TourGuideValidator tourGuideValidator = new();

            if (tourGuideValidator.Validate(tourGuideDTORequest).IsValid)
            {
                TourGuide tourGuide = _mapper.Map<TourGuide>(tourGuideDTORequest);

                await _tourGuideService.AddAsync(tourGuide);

                TourGuideDTOResponse tourGuideDTOResponse = _mapper.Map<TourGuideDTOResponse>(tourGuide);
                return Ok(ErrorResult<TourGuideDTOResponse>.SuccessWithData(tourGuideDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < tourGuideValidator.Validate(tourGuideDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(tourGuideValidator.Validate(tourGuideDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/TourGuide")]
        [ProducesResponseType(typeof(ErrorResult<List<TourGuideDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTourGuides()
        {
            var tourGuides = await _tourGuideService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (tourGuides != null)
            {
                List<TourGuideDTOResponse> tourGuideDtoResponse = new List<TourGuideDTOResponse>();

                foreach (var tourGuide in tourGuides)
                {
                    tourGuideDtoResponse.Add(_mapper.Map<TourGuideDTOResponse>(tourGuide));
                }

                return Ok(ErrorResult<List<TourGuideDTOResponse>>.SuccessWithData(tourGuideDtoResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<TourGuideDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/TourGuide/{tourGuideGUID}")]
        [ProducesResponseType(typeof(ErrorResult<TourGuideDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTourGuideByGUID(Guid tourGuideGUID)
        {
            var tourGuide = await _tourGuideService.GetAsync(q => q.GUID == tourGuideGUID);

            if (tourGuide != null)
            {
                TourGuideDTOResponse tourGuideDTOResponse = _mapper.Map<TourGuideDTOResponse>(tourGuide);

                return Ok(ErrorResult<TourGuideDTOResponse>.SuccessWithData(tourGuideDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<TourGuideDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateTourGuide")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTourGuide(TourGuideUpdateDTORequest tourGuideUpdateDTORequest)
        {
            TourGuide tourGuide = await _tourGuideService.GetAsync(q => q.GUID == tourGuideUpdateDTORequest.Guid);

           
            tourGuide.FirstName = tourGuideUpdateDTORequest.FirstName;
            tourGuide.LastName = tourGuideUpdateDTORequest.LastName;
            tourGuide.Email = tourGuideUpdateDTORequest.Email;
            tourGuide.PhoneNumber = tourGuideUpdateDTORequest.PhoneNumber;
            tourGuide.IsActive = tourGuideUpdateDTORequest.IsActive != null ? tourGuideUpdateDTORequest.IsActive : tourGuide.IsActive;

            await _tourGuideService.UpdateAsync(tourGuide);

            return Ok(ErrorResult<TourGuideDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveTourGuide/{TourGuideGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveTourGuide(Guid tourGuideGUID)
        {

            TourGuide tourGuide = await _tourGuideService.GetAsync(q => q.GUID == tourGuideGUID);

            tourGuide.IsActive = false;
            tourGuide.IsDeleted = true;

            await _tourGuideService.UpdateAsync(tourGuide);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
