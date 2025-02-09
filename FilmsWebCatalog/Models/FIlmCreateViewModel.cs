using FilmsWebCatalog.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace FilmsWebCatalog.Models
{
	public class FIlmCreateViewModel
	{
		public string Title { get; set; }
		public string DateOfReleasing { get; set; }
		public double Rating { get; set; }
		public int GenreID { get; set; }
        public int DirectorId { get; set; }

		public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Director> Director { get; set; } = new List<Director>();
	
    }
}
