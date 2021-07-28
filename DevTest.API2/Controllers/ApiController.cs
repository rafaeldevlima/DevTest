using DevTest.API2.Services;
using DevTest.Shared.Commands;
using DevTest.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTest.API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private ServiceCalcInterest _serviceCalcInterest;

        public ApiController(ILogger<ApiController> logger,ServiceCalcInterest service)
        {
            _logger = logger;
            _serviceCalcInterest = service;
       
        }

        [HttpPost("calc-interests")]
        public async Task<ActionResult<InterestCalcResultDTO>> Post([FromBody] InterestCommand command)
        {
            return await _serviceCalcInterest.CalcInterest(command);

        }
    }
}
