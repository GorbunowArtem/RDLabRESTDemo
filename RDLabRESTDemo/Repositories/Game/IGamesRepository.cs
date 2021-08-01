using System.Collections.Generic;

namespace RDLabRESTDemo.Repositories.Game
{
	public interface IGamesRepository
	{
		List<Game> Get();

		Game Get(int id);

		void Add(Game game);
		
		void Update(Game game);

		bool Delete(int id);
		
		bool NameUnique(string name);
	}
}