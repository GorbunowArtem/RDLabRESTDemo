using System.Collections.Generic;

namespace RDLabRESTDemo.Repositories.Game
{
	public class Game
	{
		public int Id { get; set; }

		public string Key { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public int UnitsInStock { get; set; }

		public Publisher Publisher { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}