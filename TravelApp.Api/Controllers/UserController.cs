using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Business.Concrete;
using System.Net;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.Mapping;
using TravelApp.Entity.DTO.User;
using TravelApp.Entity.DTO.UserDTO;
using TravelApp.Entity.POCO;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("TravelApp/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("/AddUser")]
        [ProducesResponseType(typeof(ErrorResult<UserDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser(UserDTORequest userDTORequest)
        {

            UserValidator userValidator = new();

            if (userValidator.Validate(userDTORequest).IsValid)
            {
                User user = _mapper.Map<User>(userDTORequest);

                await _userService.AddAsync(user);

                UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
                return Ok(ErrorResult<UserDTOResponse>.SuccessWithData(userDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < userValidator.Validate(userDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(userValidator.Validate(userDTORequest).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(validationMessages);
            }

        }
        [HttpGet("/User")]
        [ProducesResponseType(typeof(ErrorResult<List<UserDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false);

            if (users != null)
            {
                List<UserDTOResponse> userDtoResponse = new List<UserDTOResponse>();

                foreach (var user in users)
                {
                    userDtoResponse.Add(_mapper.Map<UserDTOResponse>(user));
                }

                return Ok(ErrorResult<List<UserDTOResponse>>.SuccessWithData(userDtoResponse));
            }

            else
            {
                return NotFound(ErrorResult<List<UserDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/User/{userGuid}")]
        [ProducesResponseType(typeof(ErrorResult<UserDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserByGUID(Guid userGuid)
        {
            var user = await _userService.GetAsync(q => q.GUID == userGuid);

            if (user != null)
            {
                UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);

                return Ok(ErrorResult<UserDTOResponse>.SuccessWithData(userDTOResponse));
            }
            else
            {
                return NotFound(ErrorResult<List<UserDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateUser")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser(UserUpdateDTORequest userUpdateDTORequest)
        {
            User user = await _userService.GetAsync(q => q.GUID == userUpdateDTORequest.GUID);

            user.Username = userUpdateDTORequest.Username;
            user.FirstName = userUpdateDTORequest.FirstName;
            user.LastName = userUpdateDTORequest.LastName;
            user.Email = userUpdateDTORequest.Email;
            user.Password = userUpdateDTORequest.Password;
            user.Adress = userUpdateDTORequest.Adress;
            user.PhoneNumber = userUpdateDTORequest.PhoneNumber;
            user.IsActive = userUpdateDTORequest.IsActive != null ? userUpdateDTORequest.IsActive : user.IsActive;

            await _userService.UpdateAsync(user);

            return Ok(ErrorResult<UserDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/RemoveUser/{userGuid}")]
        [ProducesResponseType(typeof(ErrorResult<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveUser(Guid userGuid)
        {

            User user = await _userService.GetAsync(q => q.GUID == userGuid);

            user.IsActive = false;
            user.IsDeleted = true;

            await _userService.UpdateAsync(user);

            return Ok(ErrorResult<bool>.SuccessWithData(true));
        }

    }
}
