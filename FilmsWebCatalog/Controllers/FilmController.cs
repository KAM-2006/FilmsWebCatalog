using FilmsWebCatalog.Data;
using FilmsWebCatalog.Data.Models;
using FilmsWebCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using SQLitePCL;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Security.Claims;
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Director> directors = await context.Directors.ToListAsync();
            List<Genre> genres = await context.Genres.ToListAsync();

            FIlmCreateViewModel viewModel = new FIlmCreateViewModel();
            viewModel.Director = directors;
            viewModel.Genres = genres;
			return View(viewModel);
        }
		[HttpPost]
		public async Task<IActionResult> Create(FIlmCreateViewModel film)
		{
			if (!ModelState.IsValid)
			{			
				return View(film);
			}

            Film filmNew = new Film(film.Title, film.DateOfReleasing, film.Rating, film.DirectorId, film.GenreID );

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            filmNew.UserID = userId;
            await context.Films.AddAsync(filmNew);
			await context.SaveChangesAsync();
			return RedirectToAction("Index", "Film");
		}
        [HttpGet]
        public IActionResult Delete(int id)
        {
			var film = context.Films.Find(id);
			if (film == null)
			{
				return RedirectToAction("Index", "Film");
			}
			context.Films.Remove(film);
			context.SaveChanges(true);
			return RedirectToAction("Index", "Film");
		}

        [HttpGet]
		public async Task<IActionResult> Edit(int id)
        {

			var film = context.Films.Find(id);
			if (film == null)
			{
				return RedirectToAction("Index", "Film");
			}
			var filmCreateViewModel = new FIlmCreateViewModel()
			{
				Title = film.Title,
                DateOfReleasing = film.DateOfReleasing,
                Rating = film.Rating,
                GenreID = film.GenreID,
                DirectorId = film.DirectorID
			};
			ViewData["FilmId"] = film.Id;
			List<Director> directors = await context.Directors.ToListAsync();
			List<Genre> genres = await context.Genres.ToListAsync();

			filmCreateViewModel.Director = directors;
			filmCreateViewModel.Genres = genres;
			return View(filmCreateViewModel);
		}
        [HttpPost]
		public async Task<IActionResult> Edit(int id, FIlmCreateViewModel film)
		{
			var films = context.Films.Find(id);
			if (films == null)
			{
				return RedirectToAction("Index", "Film");
			}

			if (!ModelState.IsValid)
			{
				ViewData["FilmId"] = films.Id;

				return View(films);
			}
			films.Title=film.Title;
			films.DateOfReleasing = film.DateOfReleasing;
			films.Rating=film.Rating;
            films.GenreID=film.GenreID;
            films.DirectorID=film.DirectorId;

			await context.SaveChangesAsync();

			return RedirectToAction("Index", "Film");
		}
	}
}
