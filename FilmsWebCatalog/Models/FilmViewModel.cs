using FilmsWebCatalog.Data.Models;

namespace FilmsWebCatalog.Models
{
    public class FilmViewModel
    {
        public string Title { get; set; }
        public string DateOfReleasing { get; set; }
        public double Rating { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int DirectorID { get; set; }
        public List<Director> Director { get; set; } = new List<Director> ();
    }
}
