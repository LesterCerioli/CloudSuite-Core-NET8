﻿using CloudSuite.Modules.Application.Handlers.Country;
using CloudSuite.Modules.Application.Handlers.Country.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CountryApiController> _logger;

        public CountryApiController(ILogger<CountryApiController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCountryCommand commandCreate)
        {
            var result = await _mediator.Send(commandCreate);
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpGet]
        [Route("exists/country/{countryName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CountryExists([FromForm] string countryName)
        {
            var result = await _mediator.Send(new CheckCountryExistsByCountryNameRequest(countryName));
            if (result.Errors.Any()) 
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

    }
}
