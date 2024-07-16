using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Contracts.Authentication;
using PSManagement.SharedKernel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationResponse = PSManagement.Contracts.Authentication.AuthenticationResponse;

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
            Result<AuthenticationResult> result = await _authenticationService.Login(loginRequest.Email, loginRequest.PassWorrd);

            if (result.IsSuccess) {
                AuthenticationResponse response = new (
                        result.Value.Id,
                        result.Value.FirstName,
                        result.Value.LastName,
                        result.Value.Email,
                        result.Value.Token);
                return Ok(response);
            }

            return Problem(title:"An Errorr Occured",detail:result.Error.Name,statusCode:400);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]  RegisterRequest registerRequest)
        {

            Result<AuthenticationResult> result = await _authenticationService.Register(
                    registerRequest.Email,
                    registerRequest.FirstName,
                    registerRequest.LastName,
                    registerRequest.Password);
            
            if (result.IsSuccess)
            {
                AuthenticationResponse response = new (
                        result.Value.Id,
                        result.Value.FirstName,
                        result.Value.LastName,
                        result.Value.Email,
                        result.Value.Token);
                return Ok(response);
            }

            return Problem(title: "An Errorr Occured", detail: result.Error.Name, statusCode: 400);
        }

    }
}
