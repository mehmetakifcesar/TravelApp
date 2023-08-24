using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TravelApp.Api.Aspects;
using TravelApp.Api.Validation.FluentValidation;
using TravelApp.Business.Concrete;
using TravelApp.Business.Abstract;
using TravelApp.Entity.DTO.Login;
using TravelApp.Entity.Result;

namespace TravelApp.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [ValidationFilter(typeof(LoginValidator))]
        [HttpPost("/Login")]
        [ProducesResponseType(typeof(ErrorResult<LoginDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginAsync(LoginDTORequest loginDTORequest)
        {



            var user = await _userService.GetAsync(q => q.Username == loginDTORequest.UserName && q.Password == loginDTORequest.Password);

            if (user == null)
            {
                return NotFound(ErrorResult<LoginDTOResponse>.AuthenticationError());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();
                claims.Add(new Claim("UserName", user.Username));
                claims.Add(new Claim("UserID", user.ID.ToString()));

                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(365),
                    claims: claims,
                    issuer: "http://random1235asd.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                LoginDTOResponse loginDTOResponse = new()
                {
                    Name = user.FirstName + " " + user.LastName,
                    UserID = user.ID,
                    Token = token
                };

                return Ok(ErrorResult<LoginDTOResponse>.SuccessWithData(loginDTOResponse));

            }

        }
    }
}
