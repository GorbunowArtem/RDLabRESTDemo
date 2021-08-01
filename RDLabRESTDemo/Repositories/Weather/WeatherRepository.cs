using System;
using System.Linq;

namespace RDLabRESTDemo.Repositories.Weather
{
	public class WeatherRepository : IWeatherRepository
	{
		public WeatherForecast[] Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5)
				.Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				})
				.ToArray();
		}

		public WeatherForecast Get(int id)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(WeatherForecast forecast)
		{
			throw new NotImplementedException();
		}

		public void Add(WeatherForecast forecast)
		{
			throw new NotImplementedException();
		}

		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
	}
}