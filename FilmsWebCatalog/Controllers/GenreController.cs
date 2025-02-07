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
		public IActionResult Edit(int id)
		{
			var genre = context.Genres.Find(id);
			if (genre == null)
			{
				return RedirectToAction("Index", "Genre");
			}
			var genreViewModel = new GenreViewModel()
			{
				Name = genre.Name
			};
			ViewData["GenreId"] = genre.Id;
			return View(genreViewModel);


		}
	}
}
