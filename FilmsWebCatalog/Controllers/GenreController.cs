using FilmsWebCatalog.Data;
using FilmsWebCatalog.Data.Models;
using FilmsWebCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsWebCatalog.Controllers
{
    public class GenreController : Controller
    {
        private readonly FilmsWebCatalogAppDbContext context;
        public GenreController(FilmsWebCatalogAppDbContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            var genres = context.Genres.OrderByDescending(x=>x.Id).ToList();
            return View(genres);
        }
        public IActionResult Create()
        {

            return View();
        }
		[HttpGet]
		public IActionResult Create(GenreViewModel genre)
		{
			if (!ModelState.IsValid)
			{
				return View(genre);
			}
			
			Genre genreNew = new Genre() 
			{ 
				Name = genre.Name
			};

			context.Genres.Add(genreNew);
			context.SaveChanges();

			return RedirectToAction("Index", "Genre");
		}
	}
}
