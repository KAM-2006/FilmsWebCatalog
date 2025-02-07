namespace FilmsWebCatalog.Data.Models
{
	public class FilmActor
	{
		public FilmActor()
		{

		}
		public FilmActor(int filmId, int actorId)
		{
			this.FilmId = filmId;
			this.ActorId = actorId;
		}
		public int FilmId { get; set; }
		public Film Film { get; set; }
		public int ActorId { get; set; }
		public Actor Actor { get; set; }
	}
}
