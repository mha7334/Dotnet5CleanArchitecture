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

        [HttpGet]
        [Route("call/{n}")]
        public Task<ActionResult<string>> CallMethod(string i)
        {

            if (i == "1")
            {
                
                f();
                return Task.FromResult<ActionResult<string>>(Ok("calling f"));
            }

            if (i == "2")
            {
                
                g();
                return Task.FromResult<ActionResult<string>>(Ok("calling g"));
            }

            return Task.FromResult<ActionResult<string>>(Ok("calling nothing"));
        }


        static async void f()
        {
            await h();
        }

        static async Task g()
        {
            await h();
        }

        static async Task h()
        {
            await Task.FromResult("abc");
            throw new Exception();
        }
    }
}
