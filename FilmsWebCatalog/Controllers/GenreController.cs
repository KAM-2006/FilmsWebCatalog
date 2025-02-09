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
		[HttpGet]
        public IActionResult Create()
        {

            return View();
        }
		[HttpPost]
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
		[HttpGet]
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
		[HttpPost]
		public IActionResult Edit(int id, GenreViewModel genre)
		{
			var genres = context.Genres.Find(id);
			if (genres == null)
			{
				return RedirectToAction("Index", "Genre");
			}

			if (!ModelState.IsValid)
			{
				ViewData["GenreId"] = genres.Id;
				
				return View(genre);
			}
			genres.Name = genre.Name;

			context.SaveChanges();

			return RedirectToAction("Index", "Genre");
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var genre = context.Genres.Find(id);
			if (genre == null)
			{
				return RedirectToAction("Index", "Genre");
			}
			context.Genres.Remove(genre);
			context.SaveChanges(true);
			return RedirectToAction("Index", "Genre");
		}
	}
}
