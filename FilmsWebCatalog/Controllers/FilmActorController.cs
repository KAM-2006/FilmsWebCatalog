using FilmsWebCatalog.Data;
using FilmsWebCatalog.Data.Models;
using FilmsWebCatalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static FilmsWebCatalog.Common.AdminUser;

namespace FilmsWebCatalog.Controllers
{
	public class FilmActorController : Controller
	{
		private readonly FilmsWebCatalogAppDbContext context;
		public FilmActorController(FilmsWebCatalogAppDbContext _context)
		{
			this.context = _context;
		}
		public IActionResult Index()
		{
            List<FilmActor> list = FillFilmActor().OrderByDescending(x => x.FilmId).ToList();
            return View(list);
		}
        public List<FilmActor> FillFilmActor()
        {
            List<FilmActor> list = context.FilmsActors.ToList();
            foreach (var item in list)
            {
                Film film = OneFilm(item.FilmId);
                item.Film = film;
                Actor actor = OneActor(item.ActorId);
                item.Actor = actor;
            }
            return list;
        }
        public Film OneFilm(int id)
        {
            List<Film> films = context.Films.ToList();
            foreach (var item in films)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null!;
        }
        public Actor OneActor(int id)
        {
            List<Actor> actors = context.Actors.ToList();
            foreach (var item in actors)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null!;
        }
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Create()
        {
            List<Film> films = await context.Films.ToListAsync();
            List<Actor> actors = await context.Actors.ToListAsync();

            //FIlmCreateViewModel viewModel = new FIlmCreateViewModel();
            FilmActorViewModel viewModel = new FilmActorViewModel();
            viewModel.Films = films;
            viewModel.Actors = actors;
            return View(viewModel);
        }
		[HttpPost]
		public async Task<IActionResult> Create(FilmActorViewModel item)
		{
			if (!ModelState.IsValid)
			{
				return View(item);
			}

			FilmActor filmNew = new FilmActor(item.FilmId, item.ActorId);

			await context.FilmsActors.AddAsync(filmNew);
			await context.SaveChangesAsync();
			return RedirectToAction("Index", "FilmActor");
		}
	}
}
