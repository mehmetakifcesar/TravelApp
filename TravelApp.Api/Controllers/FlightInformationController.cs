using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Abstract;
using TravelApp.Entity.DTO.FlightInformation;
using TravelApp.Business.Concrete;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[action]")]
    public class FlightInformationController : Controller
    {
        private readonly IFlightInformationService _flightInformationService;
        private readonly IMapper _mapper;
        public FlightInformationController(IFlightInformationService flightInformationService, IMapper mapper)
        {
            _flightInformationService = flightInformationService;
            _mapper = mapper;
        }
        [HttpPost("/AddFlightInformation")]
        [ProducesResponseType(typeof(ErrorResult<FlightInformationDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddFlightInformation(FlightInformationDTORequest flightInformationDTORequest)
        {

            FlightInformationValidator flightInformationValidator = new();

            if (flightInformationValidator.Validate(flightInformationDTORequest).IsValid)
            {
                FlightInformation flightInformation = _mapper.Map<FlightInformation>(flightInformationDTORequest);

                await _flightInformationService.AddAsync(flightInformation);

                FlightInformationDTOResponse flightInformationDTOResponse = _mapper.Map<FlightInformationDTOResponse>(flightInformation);
                return Ok(ErrorResult<FlightInformationDTOResponse>.SuccessWithData(flightInformationDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < flightInformationValidator.Validate(flightInformationDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(flightInformationValidator.Validate(flightInformationDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/FlightInformation")]
        [ProducesResponseType(typeof(ErrorResult<List<FlightInformationDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFlightInformations()
        {
            var flightInformations = await _flightInformationService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (flightInformations != null)
            {
                List<FlightInformationDTOResponse> FlightInformationDTOResponse = new List<FlightInformationDTOResponse>();

                foreach (var flightInformation in flightInformations)
                {
                    FlightInformationDTOResponse.Add(_mapper.Map<FlightInformationDTOResponse>(flightInformation));
                }

                return Ok(ErrorResult<List<FlightInformationDTOResponse>>.SuccessWithData(FlightInformationDTOResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<FlightInformationDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/FlightInformation/{flightInformationGUID}")]
        [ProducesResponseType(typeof(ErrorResult<FlightInformationDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFlightInformationByGUID(Guid flightInformationGUID)
        {
            var flightInformation = await _flightInformationService.GetAsync(q => q.GUID == flightInformationGUID);

            if (flightInformation != null)
            {
                FlightInformationDTOResponse flightInformationDTOResponse = _mapper.Map<FlightInformationDTOResponse>(flightInformation);

                return Ok(ErrorResult<FlightInformationDTOResponse>.SuccessWithData(flightInformationDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<FlightInformationDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateFlightInformation")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateFlightInformation(FlightInformationUpdateDTORequest flightInformationUpdateDTORequest)
        {
            FlightInformation flightInformation = await _flightInformationService.GetAsync(q => q.GUID == flightInformationUpdateDTORequest.Guid);

            flightInformation.Airline = flightInformationUpdateDTORequest.Airline;
            flightInformation.DepartureDate = flightInformationUpdateDTORequest.DepartureDate;
            flightInformation.ArrivalDate = flightInformationUpdateDTORequest.ArrivalDate;
            flightInformation.Origin = flightInformationUpdateDTORequest.Origin;
            flightInformation.Destination = flightInformationUpdateDTORequest.Destination;
            flightInformation.Price = flightInformationUpdateDTORequest.Price;


            flightInformation.IsActive = flightInformationUpdateDTORequest.IsActive != null ? flightInformationUpdateDTORequest.IsActive : flightInformation.IsActive;

            await _flightInformationService.UpdateAsync(flightInformation);

            return Ok(ErrorResult<FlightInformationDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveFlightInformation/{flightInformationGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveFlightInformation(Guid flightInformationGUID)
        {

            FlightInformation flightInformation = await _flightInformationService.GetAsync(q => q.GUID == flightInformationGUID);

            flightInformation.IsActive = false;
            flightInformation.IsDeleted = true;

            await _flightInformationService.UpdateAsync(flightInformation);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
