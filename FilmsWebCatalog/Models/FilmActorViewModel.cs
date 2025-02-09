using FilmsWebCatalog.Data.Models;

namespace FilmsWebCatalog.Models
{
	public class FilmActorViewModel
	{
		public int FilmId { get; set; }
		public int ActorId { get; set; }

		public List<Film> Films { get; set; } = new List<Film>();
		public List<Actor> Actors { get; set; } = new List<Actor>();
	}
}
