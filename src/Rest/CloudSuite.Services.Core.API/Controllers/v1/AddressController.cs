using CloudSuite.Modules.Application.Hadlers.Address;
using CloudSuite.Modules.Application.Hadlers.Address.Requests;
using CloudSuite.Modules.Application.Validations.Address;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Core.API.Controllers.v1
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressController : ControllerBase
	{
		private readonly ILogger<CreateAddressCommand> _logger;
		private readonly IMediator _mediator;

		public AddressController(ILogger<CreateAddressCommand> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] CreateAddressCommand createCommand)
		{
			var result = await _mediator.Send(createCommand);
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
		[Route("exists/addressLine1/{addressLine1}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddressLinesExists([FromRoute] string addressLine1)
		{
			var result = _mediator.Send(new CheckAddressExistsByAddressLineRequest(addressLine1));
			if (result.Result.Errors.Any())
			{
				return BadRequest(result);
			}
			if (result.Result.Exists)
			{
				return Ok(result);
			}

			else
			{
				return Ok(result);
			}

		}
	}
}
