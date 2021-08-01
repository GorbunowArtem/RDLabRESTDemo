using System;
using System.Collections.Generic;
using System.Linq;

namespace RDLabRESTDemo.Repositories.Game
{
	public class GamesRepository : IGamesRepository
	{
		private static readonly List<Game> _games =
			Enumerable.Range(1, 50)
				.Select(g => new Game
				{
					Id = g,
					Key = Faker.Company.BS(),
					Name = Faker.Company.Name(),
					Price = 50m,
					Description = Faker.Lorem.Sentence(),
					Publisher = new Publisher
					{
						Id = g,
						Name = Faker.Name.FullName()
					},
					Comments = new List<Comment>
					{
						new()
						{
							Id = g,
							Body = Faker.Lorem.Paragraph()
						},
						new()
						{
							Id = g,
							Body = Faker.Lorem.Paragraph()
						},
						new()
						{
							Id = g,
							Body = Faker.Lorem.Paragraph()
						},
						new()
						{
							Id = g,
							Body = Faker.Lorem.Paragraph()
						},
					}
				})
				.ToList();

		public List<Game> Get() =>
			_games;

		public Game Get(int id) =>
			_games.FirstOrDefault(g => g.Id == id);

		public void Add(Game game) =>
			_games.Add(game);

		public void Update(Game game)
		{
			_games.Remove(game);
			_games.Add(game);
		}

		public bool Delete(int id)
		{
			var game = _games.FirstOrDefault(g => g.Id == id);

			if (game is null)
			{
				return false;
			}

			return _games.Remove(game);
		}

		public bool NameUnique(string name)
		{
			return _games.FirstOrDefault(g => string.Equals(g.Name, name, StringComparison.OrdinalIgnoreCase)) == null;
		}
	}
}