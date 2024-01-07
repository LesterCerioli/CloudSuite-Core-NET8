using CloudSuite.Modules.Application.Hadlers.City.Request;
using CloudSuite.Modules.Application.Hadlers.City;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CloudSuite.Services.Core.API.Controllers.v1
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly ILogger<CityController> _logger;
		private readonly IMediator _mediator;

		public CityController(ILogger<CityController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] CreateCityCommand commandCreate)
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
		[Route("exists/addressLine1/{cityName}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CityExists([FromRoute] string cityName)
		{
			

		}
	}
}
