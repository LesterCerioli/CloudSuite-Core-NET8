using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.PasswordGenerator
{
	[Route("api/[controller]")]
	[ApiController]
	public class PasswordApiController : ControllerBase
	{
		private readonly ILogger<PasswordApiController> _logger;
		private readonly IMediator _mediator;

		public PasswordApiController(ILogger<PasswordApiController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] CreatePasswordCommand commandCreate)
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
	}
}
