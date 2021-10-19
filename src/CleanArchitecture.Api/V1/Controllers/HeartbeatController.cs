using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Api.ApiContstants;
using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Api.V1.Controllers
{
    [Route("api/" + ApiConstants.ApiName + "/v{api-version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class HeartbeatController : Controller
    {
      
        [HttpGet]
        [Route("ping")]
        public Task<ActionResult<bool>> PingAsync()
        {
            return Task.FromResult<ActionResult<bool>>(Ok(true));
        }
    }
}
