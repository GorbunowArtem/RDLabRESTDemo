using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RDLabRESTDemo.Controllers;
using RDLabRESTDemo.Repositories.Game;
using RDLabRESTDemo.Repositories.Weather;
using Sciensoft.Hateoas.Extensions;

namespace RDLabRESTDemo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddJsonOptions(ops =>
				{
					ops.JsonSerializerOptions.IgnoreNullValues = true;
					ops.JsonSerializerOptions.WriteIndented = true;
					ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
					ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
					ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				})
				.AddLink(policy =>
				{
					policy.AddPolicy<Game>(game =>
					{
						game.AddSelf(g => g.Id)
							.AddRoute(g => g.Id, "Update")
							.AddRoute(g => g.Id, "PartialUpdate")
							.AddRoute(g => g.Id, "Delete")
							.AddRoute( g => g.Id, "Add");
					});

					policy.AddPolicy<Publisher>(publisher =>
					{
						publisher.AddSelf(p => p.Id);
					});
				});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo {Title = "RDLabRESTDemo", Version = "v1"});
			});

			services.AddTransient<IGamesRepository, GamesRepository>();
			services.AddTransient<IWeatherRepository, WeatherRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RDLabRESTDemo v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}