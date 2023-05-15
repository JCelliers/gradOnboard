using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppNamespace.Models;
using Onboarding.Interfaces.Repository;
using Onboarding.Repository;

namespace Onboarding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public AuthController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> LoginAuth(string username, string password)
        {
            var isValid = await _loginRepository.AuthLogin(username, password);
            if (isValid) 
            {
                return Ok("Good");
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Invalid email or password");
            }
        }
    }
}
