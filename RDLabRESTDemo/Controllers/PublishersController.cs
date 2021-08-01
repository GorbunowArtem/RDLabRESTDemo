using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace RDLabRESTDemo.Controllers
{
	[ApiController]
	[Consumes(MediaTypeNames.Application.Json)]
	[Produces(MediaTypeNames.Application.Json)]
	[Route("api/v1/publishers")]
	public class PublishersController : ControllerBase
	{
		[HttpGet("{id:int}")]
		public IActionResult Get(int id)
		{
			return Ok();
		}
	}
}