using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Abstract;
using TravelApp.Business.Concrete;
using TravelApp.Entity.DTO.TourCompany;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[action]")]
    public class TourCompanyCompanyController : Controller
    {
       private readonly ITourCompanyService _tourCompanyService;
        private readonly IMapper _mapper;
        public TourCompanyCompanyController(ITourCompanyService tourCompanyService, IMapper mapper)
        {
            _tourCompanyService = tourCompanyService;
            _mapper = mapper;
        }
        [HttpPost("/AddTourCompany")]
        [ProducesResponseType(typeof(ErrorResult<TourCompanyDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddTourCompany(TourCompanyDTORequest tourCompanyDTORequest)
        {

            TourCompanyValidator tourCompanyValidator = new();

            if (tourCompanyValidator.Validate(tourCompanyDTORequest).IsValid)
            {
                TourCompany tourCompany = _mapper.Map<TourCompany>(tourCompanyDTORequest);

                await _tourCompanyService.AddAsync(tourCompany);

                TourCompanyDTOResponse tourCompanyDTOResponse = _mapper.Map<TourCompanyDTOResponse>(tourCompany);
                return Ok(ErrorResult<TourCompanyDTOResponse>.SuccessWithData(tourCompanyDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < tourCompanyValidator.Validate(tourCompanyDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(tourCompanyValidator.Validate(tourCompanyDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/TourCompany")]
        [ProducesResponseType(typeof(ErrorResult<List<TourCompanyDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTourCompanies()
        {
            var tourCompanies = await _tourCompanyService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (tourCompanies != null)
            {
                List<TourCompanyDTOResponse> tourCompanyDtoResponse = new List<TourCompanyDTOResponse>();

                foreach (var tourCompany in tourCompanies)
                {
                    tourCompanyDtoResponse.Add(_mapper.Map<TourCompanyDTOResponse>(tourCompany));
                }

                return Ok(ErrorResult<List<TourCompanyDTOResponse>>.SuccessWithData(tourCompanyDtoResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<TourCompanyDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/TourCompany/{tourCompanyGUID}")]
        [ProducesResponseType(typeof(ErrorResult<TourCompanyDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTourCompanyByGUID(Guid tourCompanyGUID)
        {
            var tourCompany = await _tourCompanyService.GetAsync(q => q.GUID == tourCompanyGUID);

            if (tourCompany != null)
            {
                TourCompanyDTOResponse tourCompanyDTOResponse = _mapper.Map<TourCompanyDTOResponse>(tourCompany);

                return Ok(ErrorResult<TourCompanyDTOResponse>.SuccessWithData(tourCompanyDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<TourCompanyDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateTourCompany")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTourCompany(TourCompanyUpdateDTORequest tourCompanyUpdateDTORequest)
        {
            TourCompany tourCompany = await _tourCompanyService.GetAsync(q => q.GUID == tourCompanyUpdateDTORequest.Guid);


            tourCompany.Name = tourCompanyUpdateDTORequest.Name;
            tourCompany.Email = tourCompanyUpdateDTORequest.Email;
            tourCompany.Adress = tourCompanyUpdateDTORequest.Adress;
            tourCompany.PhoneNumber = tourCompanyUpdateDTORequest.PhoneNumber;
           
            tourCompany.IsActive = tourCompanyUpdateDTORequest.IsActive != null ? tourCompanyUpdateDTORequest.IsActive : tourCompany.IsActive;

            await _tourCompanyService.UpdateAsync(tourCompany);

            return Ok(ErrorResult<TourCompanyDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveTourCompany/{tourCompanyGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveTourCompany(Guid TourCompanyGUID)
        {

            TourCompany tourCompany = await _tourCompanyService.GetAsync(q => q.GUID == TourCompanyGUID);

            tourCompany.IsActive = false;
            tourCompany.IsDeleted = true;

            await _tourCompanyService.UpdateAsync(tourCompany);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
