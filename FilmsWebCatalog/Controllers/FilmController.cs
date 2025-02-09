using FilmsWebCatalog.Data;
using FilmsWebCatalog.Data.Models;
using Microsoft.AspNetCore.Mvc;
using static FilmsWebCatalog.Data.Models.Genre;

namespace FilmsWebCatalog.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmsWebCatalogAppDbContext context;
        public FilmController(FilmsWebCatalogAppDbContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            List<Film> films = FillGenreDirector().OrderByDescending(x => x.Id).ToList();
           // var films = context.Films.OrderByDescending(x => x.Id).ToList();
            return View(films);
        }
        public List<Film> FillGenreDirector()
        {
            List<Film> films = context.Films.ToList();
            foreach (var item in films)
            {
                Genre genre = OneGenre(item.GenreID);
                item.Genre = genre;
                Director director = OneDirector(item.DirectorID);
                item.Director = director;
            }
            return films;   
        }
        public Genre OneGenre(int id)
        {
            List<Genre> genres = context.Genres.ToList();
            foreach(var item in genres)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null!;
        }
        public Director OneDirector(int id)
        {
            List<Director> directors = context.Directors.ToList();
            foreach(var item in directors)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null!;
        }
    }
}
