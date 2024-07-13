using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            AuthenticationResult result = await  _authenticationService.Login(loginRequest.Email,loginRequest.PassWorrd);

            AuthenticationResponse response = new AuthenticationResponse(
                    result.Id,
                    result.FirstName,
                    result.LastName,
                    result.Email,
                    result.Token);
            return  Ok(response);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]  RegisterRequest registerRequest)
        {

            AuthenticationResult result = await  _authenticationService.Register(
                    registerRequest.Email,
                    registerRequest.FirstName,
                    registerRequest.LastName,
                    registerRequest.Password);

            AuthenticationResponse response = new AuthenticationResponse(
                    result.Id,
                    result.FirstName,
                    result.LastName,
                    result.Email,
                    result.Token);
            return Ok(response);
        }

    }
}
