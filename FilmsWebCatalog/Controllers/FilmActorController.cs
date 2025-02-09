﻿using FilmsWebCatalog.Data;
using FilmsWebCatalog.Data.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
