using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers.ApiBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return Problem(detail: result.Errors.FirstOrDefault(), statusCode: StatusCodes.Status400BadRequest);
            }
        }

    }
}
