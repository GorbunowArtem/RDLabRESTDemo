using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using RDLabRESTDemo.Repositories.Game;

namespace RDLabRESTDemo.Controllers
{
	[ApiController]
	[Consumes(MediaTypeNames.Application.Json)]
	[Produces(MediaTypeNames.Application.Json)]
	[Route("api/v1/games")]
	public class GamesController : ControllerBase
	{
		private readonly IGamesRepository _gamesRepository;

		public GamesController(IGamesRepository gamesRepository)
		{
			_gamesRepository = gamesRepository;
		}

		[HttpGet]
		[ProducesResponseType((int) HttpStatusCode.OK)]
		public ActionResult<List<Game>> Get() =>
			Ok(_gamesRepository.Get());


		[HttpGet("{id:int}", Name = "Get")]
		[ProducesResponseType((int) HttpStatusCode.NotFound)]
		[ProducesResponseType((int) HttpStatusCode.OK)]
		public ActionResult<Game> Get(int id)
		{
			var game = _gamesRepository.Get(id);

			if (game is null)
			{
				return NotFound();
			}

			return Ok(game);
		}

		[HttpPost(Name = "Add")]
		[ProducesResponseType((int) HttpStatusCode.Created)]
		public ActionResult<Game> Add([FromBody] Game game)
		{
			_gamesRepository.Add(game);

			return CreatedAtAction(nameof(Add), "api/v1/games", game);
		}

		[HttpPut("{id:int}", Name = "Update")]
		[ProducesResponseType((int) HttpStatusCode.OK)]
		public IActionResult Update(int id, [FromBody] Game game)
		{
			_gamesRepository.Update(game);
			return Ok();
		}

		[HttpPatch("{id:int}", Name = "PartialUpdate")]
		[ProducesResponseType((int) HttpStatusCode.OK)]
		public IActionResult Update(int id, string title)
		{
			return Ok();
		}

		[HttpDelete("{id:int}", Name = "Delete")]
		[ProducesResponseType((int) HttpStatusCode.NoContent)]
		[ProducesResponseType((int) HttpStatusCode.OK)]
		public IActionResult Delete(int id)
		{
			var deleted = _gamesRepository.Delete(id);

			return deleted ? Ok() : NoContent();
		}

		[HttpHead]
		[ProducesResponseType((int) HttpStatusCode.OK)]
		[ProducesResponseType((int) HttpStatusCode.Conflict)]
		public IActionResult NameUnique(string name)
		{
			if (_gamesRepository.NameUnique(name))
			{
				return Ok();
			}

			return Conflict();
		}

		[HttpOptions]
		public IActionResult Options()
		{
			HttpContext.Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
			return Ok();
		}
	}
}