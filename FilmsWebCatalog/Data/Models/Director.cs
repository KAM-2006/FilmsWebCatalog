using System.ComponentModel.DataAnnotations;

namespace FilmsWebCatalog.Data.Models
{
	public class Director
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string DateOfBirth { get; set; }
		//public ICollection<Film> Films { get; set; }
	}
}
