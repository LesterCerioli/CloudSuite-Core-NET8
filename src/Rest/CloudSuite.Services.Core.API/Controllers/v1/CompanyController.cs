using CloudSuite.Modules.Application.Hadlers.City;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Company.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.API.Controllers.v1
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ILogger<CompanyController> _logger;
		private readonly IMediator _medoator;
		private readonly object _mediator;

		public CompanyController(ILogger<CompanyController> logger, IMediator mediator)
		{
			_logger = logger;
			_medoator = mediator;

		}


		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] CreateCompanyCommand commandCreate)
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
		[Route("exists/cnpj/{cnpj}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CnpjExists([FromRoute] string cnpj)
		{
			var result = await _medoator.Send(new CheckCompanyExistsByCnpjRequest(cnpj));
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
