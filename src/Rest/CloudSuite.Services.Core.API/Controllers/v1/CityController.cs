using CloudSuite.Modules.Application.Hadlers.City;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> Post([FromBody] CreateCityCommand createCommand)
        {

		}


        // GET: api/<CityController>
        [HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<CityController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CityController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CityController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CityController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
