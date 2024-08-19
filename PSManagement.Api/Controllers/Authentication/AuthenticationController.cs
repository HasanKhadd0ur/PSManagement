﻿using System.Linq;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Contracts.Authentication;
using System.Threading.Tasks;
using AuthenticationResponse = PSManagement.Contracts.Authentication.AuthenticationResponse;

namespace PSManagement.Api.Controllers.Authentication
{
    [Route("api/[controller]")]
    public class AuthenticationController : APIController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            Result<AuthenticationResult> result = await _authenticationService.Login(loginRequest.Email, loginRequest.PassWord);

            if (result.IsSuccess) {
                AuthenticationResponse response = new (
                        result.Value.EmployeeId,
                        result.Value.FirstName,
                        result.Value.LastName,
                        result.Value.Email,
                        result.Value.Roles,
                        result.Value.Token);
                return Ok(response);
            }

            return Problem(title: result.ValidationErrors.FirstOrDefault().ErrorCode,detail:result.ValidationErrors.FirstOrDefault().ErrorMessage,statusCode:401);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]  RegisterRequest registerRequest)
        {

            Result<AuthenticationResult> result = await _authenticationService.Register(
                    registerRequest.Email,
                    registerRequest.Email,
                    registerRequest.Password);
            
            if (result.IsSuccess)
            {
                AuthenticationResponse response = new (
                        result.Value.EmployeeId,
                        result.Value.FirstName,
                        result.Value.LastName,
                        result.Value.Email,
                        result.Value.Roles,
                        result.Value.Token);
                return Ok(response);
            }

            return Problem(title: "An Errorr Occured " , detail:"", statusCode: 400);
        }

    }
}
