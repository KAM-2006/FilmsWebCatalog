using System.ComponentModel.DataAnnotations;

namespace FilmsWebCatalog.Data.Models
{
	public class Genre
	{
		public Genre()
		{

		}
		public Genre(string name)
		{
			this.Name = name;
		}
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		//public ICollection<Film> Films { get; set; }
	}
}
