using System.ComponentModel.DataAnnotations;

namespace FilmsWebCatalog.Data.Models
{
	public class Actor
	{
		public Actor()
		{

		}
		public Actor(string firstName, string lastName, int years, string DOB)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Years = years;
			this.DateOfBirth = DOB;
		}
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public int Years { get; set; }
		public string DateOfBirth { get; set; }
		public ICollection<FilmActor> FilmsActors { get; set; }

		public override string ToString()
		{
			return $"{this.FirstName} {this.LastName} {this.Years} {this.DateOfBirth}";
		}
	}
}
