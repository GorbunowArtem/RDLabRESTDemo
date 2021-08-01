using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RDLabRESTDemo.Repositories.Weather;

namespace RDLabRESTDemo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IWeatherRepository _weatherRepository;

		public WeatherForecastController(IWeatherRepository weatherRepository)
		{
			_weatherRepository = weatherRepository;
		}

		[HttpGet]
		[Route("getForecasts")]
		public IEnumerable<WeatherForecast> Get() =>
			_weatherRepository.Get();

		[HttpGet]
		[Route("getById{id:int}")]
		public IEnumerable<WeatherForecast> Get(int id) =>
			_weatherRepository.Get();

		[HttpPost]
		[Route("newForecast")]
		public void Add([FromBody] WeatherForecast forecast) =>
			_weatherRepository.Add(forecast);

		[HttpPost]
		[Route("delete{id:int}")]
		public void Delete(int id) =>
			_weatherRepository.Delete(id);

		[HttpPut]
		[Route("update")]
		public void Update(WeatherForecast forecast) =>
			_weatherRepository.Update(forecast);
	}
}