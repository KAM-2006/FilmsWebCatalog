using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FilmsWebCatalog.Data.Models
{
	public class Film
	{
		public Film()
		{

		}
		public Film(string title, string dateOfReleasing,
			double rating, int directorId, int genreId)
		{
			this.Title = title;
			this.DateOfReleasing = dateOfReleasing;
			this.Rating = rating;
			this.GenreID = genreId;
			this.DirectorID = directorId;	
		}
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string DateOfReleasing { get; set; }
		public double Rating { get; set; }
		public int GenreID { get; set; }
		public Genre Genre { get; set; }
		public int DirectorID { get; set; }
		public Director Director { get; set; }
		public ICollection<FilmActor> FilmsActors { get; set; }

		[Required]
		public string UserID { get; set; } = null!;
		public IdentityUser User { get; set; } = null!;

		public override string ToString()
		{
			return $"{this.Title} - {this.DateOfReleasing}, {this.Rating}/10 {this.GenreID} {this.DirectorID}.";
		}
	}
}
