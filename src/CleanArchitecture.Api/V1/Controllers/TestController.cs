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
    public class TestController : Controller
    {
        private readonly IGadgetService _service;

        public TestController(IGadgetService service) => _service = service;

        [HttpGet]
        public async Task<IEnumerable<GadgetDto>> Get()
        {
            throw new ArgumentNullException();
            var gadgets = await _service.GetAllGadgets();
            return gadgets.MapList<Gadget, GadgetDto>();
        }
    }
}
