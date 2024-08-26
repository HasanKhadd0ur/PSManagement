using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Presentation.Controllers.ApiBase
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
                return Problem(
                    detail: result.ValidationErrors.FirstOrDefault().ErrorMessage,
                    statusCode: StatusCodes.Status400BadRequest,
                    title:result.ValidationErrors.FirstOrDefault().ErrorCode
                    );
            }
        }

    }
}
