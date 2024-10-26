using DriverLicenseTestBE.Services;
using DriverLicenseTestBE.Utils;
using DriverLicenseTestBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DriverLicenseTestBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginVM model)
        {
            if (!model.IsValid(out List<ValidationResult> messageCheck)) return BadRequest(messageCheck.First().ErrorMessage);

            string msg = _authenticationService.Login(model, out object obj);
            if (msg.Length > 0) return BadRequest(msg);

            return Ok(obj);
        }

        [HttpPost("Register")]
        public IActionResult Register(UserRegisterVM model)
        {
            if (!model.IsValid(out List<ValidationResult> messageCheck)) return BadRequest(messageCheck.First().ErrorMessage);

            string msg = _authenticationService.Register(model);
            if (msg.Length > 0) return BadRequest(msg);

            return Ok();
        }
    }
}
