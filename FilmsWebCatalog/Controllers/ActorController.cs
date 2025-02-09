using FilmsWebCatalog.Data;
using FilmsWebCatalog.Data.Models;
using FilmsWebCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsWebCatalog.Controllers
{
    public class ActorController : Controller
    {
        private readonly FilmsWebCatalogAppDbContext context;
        public ActorController(FilmsWebCatalogAppDbContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            var actors = context.Actors.OrderByDescending(x => x.Id).ToList();
            return View(actors);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
		[HttpPost]
		public IActionResult Create(ActorViewModel actor)
		{
			if (!ModelState.IsValid)
			{
				return View(actor);
			}

			Actor actorNew = new Actor()
			{
				FirstName = actor.FirstName,
				LastName = actor.LastName,
				Years = actor.Years,
				DateOfBirth = actor.DateOfBirth
			};

			context.Actors.Add(actorNew);
			context.SaveChanges();
			return RedirectToAction("Index", "Actor");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{

			var actor = context.Actors.Find(id);
			if (actor == null)
			{
				return RedirectToAction("Index", "Actor");
			}
			var actorViewModel = new ActorViewModel()
			{
				FirstName = actor.FirstName,
				LastName = actor.LastName,
				Years = actor.Years,
				DateOfBirth = actor.DateOfBirth
			};
			ViewData["ActorId"] = actor.Id;
			return View(actorViewModel);
		}
		[HttpPost]
		public IActionResult Edit(int id, ActorViewModel actor)
		{
			var actors = context.Actors.Find(id);
			if (actors == null)
			{
				return RedirectToAction("Index", "Actor");
			}

			if (!ModelState.IsValid)
			{
				ViewData["ActorId"] = actors.Id;

				return View(actor);
			}
			actors.FirstName = actor.FirstName;
			actors.LastName = actor.LastName;
			actors.Years = actor.Years;
			actors.DateOfBirth = actor.DateOfBirth;
			context.SaveChanges();

			return RedirectToAction("Index", "Actor");
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var actor = context.Actors.Find(id);
			if (actor == null)
			{
				return RedirectToAction("Index", "Actor");
			}
			context.Actors.Remove(actor);
			context.SaveChanges(true);
			return RedirectToAction("Index", "Actor");
		}
	}
}
