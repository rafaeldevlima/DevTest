using DevTest.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {


        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet("interest-rate")]
        public async Task<ActionResult<InterestRateDTO>> Get()
        {
            return new InterestRateDTO { rate = 1 };
          
        }
    }
}
