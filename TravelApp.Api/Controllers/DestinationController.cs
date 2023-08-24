using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Abstract;
using TravelApp.Business.Concrete;
using TravelApp.Entity.DTO.Destination;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[Action")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;
        public DestinationController(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }
        [HttpPost("/AddDestination")]
        [ProducesResponseType(typeof(ErrorResult<DestinationDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddDestination(DestinationDTORequest destinationDTORequest)
        {

            DestinationValidator destinationValidator = new();

            if (destinationValidator.Validate(destinationDTORequest).IsValid)
            {
                Destination destination = _mapper.Map<Destination>(destinationDTORequest);

                await _destinationService.AddAsync(destination);

                DestinationDTOResponse destinationDTOResponse = _mapper.Map<DestinationDTOResponse>(destination);
                return Ok(ErrorResult<DestinationDTOResponse>.SuccessWithData(destinationDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < destinationValidator.Validate(destinationDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(destinationValidator.Validate(destinationDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/Destination")]
        [ProducesResponseType(typeof(ErrorResult<List<DestinationDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDestinations()
        {
            var destinations = await _destinationService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (destinations != null)
            {
                List<DestinationDTOResponse> destinationDTOResponse = new List<DestinationDTOResponse>();

                foreach (var destination in destinations)
                {
                    destinationDTOResponse.Add(_mapper.Map<DestinationDTOResponse>(destination));
                }

                return Ok(ErrorResult<List<DestinationDTOResponse>>.SuccessWithData(destinationDTOResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<DestinationDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/Destination/{destinationGUID}")]
        [ProducesResponseType(typeof(ErrorResult<DestinationDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDestinationByGUID(Guid destinationGUID)
        {
            var destination = await _destinationService.GetAsync(q => q.GUID == destinationGUID);

            if (destination != null)
            {
                DestinationDTOResponse destinationDTOResponse = _mapper.Map<DestinationDTOResponse>(destination);

                return Ok(ErrorResult<DestinationDTOResponse>.SuccessWithData(destinationDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<DestinationDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateDestination")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDestination(DestinationUpdateDTORequest destinationUpdateDTORequest)
        {
            Destination destination = await _destinationService.GetAsync(q => q.GUID == destinationUpdateDTORequest.Guid);

            destination.Name = destinationUpdateDTORequest.Name;
            destination.Description = destinationUpdateDTORequest.Description;
            destination.Country = destinationUpdateDTORequest.Country;
            destination.City = destinationUpdateDTORequest.City;

            destination.IsActive = destinationUpdateDTORequest.IsActive != null ? destinationUpdateDTORequest.IsActive : destination.IsActive;

            await _destinationService.UpdateAsync(destination);

            return Ok(ErrorResult<DestinationDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveDestination/{destinationGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveDestination(Guid destinationGUID)
        {

            Destination destination = await _destinationService.GetAsync(q => q.GUID == destinationGUID);

            destination.IsActive = false;
            destination.IsDeleted = true;

            await _destinationService.UpdateAsync(destination);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }
    }
}
