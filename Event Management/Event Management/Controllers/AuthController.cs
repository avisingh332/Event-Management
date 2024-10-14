using Event_Management.Business.Dtos.RequestDto;
using Event_Management.Business.Dtos.ResponseDto;
using Event_Management.Business.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;
        public AuthController(IAuthService authService)
        {
            _authservice = authService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequest)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Email Or Password is Incorrect");
                return ValidationProblem(ModelState);
            }
            else
            {

                var loginResponse = await _authservice.Login(loginRequest);
                if (loginResponse == null)
                {
                    ModelState.AddModelError("", "Email Or Password is Incorrect");
                    return ValidationProblem(ModelState);
                }
                else
                {
                    return Ok(loginResponse);
                }
            }

        }
    }
}
