namespace RDLabRESTDemo.Repositories.Weather
{
	public interface IWeatherRepository
	{
		WeatherForecast[] Get();
		
		WeatherForecast Get(int id);

		void Delete(int id);

		void Update(WeatherForecast forecast);

		void Add(WeatherForecast forecast);
	}
}