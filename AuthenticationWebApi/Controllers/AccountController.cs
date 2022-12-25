using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AccountController : ControllerBase
    {

        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost]
        public ActionResult<AuthenticateResponse?> Authenticate([FromBody] AuthenticateRequest authenticateRequest)
        {
            var authenticationResponse = _jwtTokenHandler.GeneraJwtToken(authenticateRequest);
            if (authenticateRequest == null) return Unauthorized();
            return authenticationResponse;
        }
    }
}
