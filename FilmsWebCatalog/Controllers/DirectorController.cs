using FilmsWebCatalog.Data;
using FilmsWebCatalog.Data.Models;
using FilmsWebCatalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FilmsWebCatalog.Common.AdminUser;

namespace FilmsWebCatalog.Controllers
{
    public class DirectorController : Controller
    {
        private readonly FilmsWebCatalogAppDbContext context;
        public DirectorController(FilmsWebCatalogAppDbContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            var directors = context.Directors.OrderByDescending(x => x.Id).ToList();
            return View(directors);
        }
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Create()
        {

            return View();
        }
		[HttpPost]
		public IActionResult Create(DirectorViewModel director)
		{
			if (!ModelState.IsValid)
			{
				return View(director);
			}

			Director directorNew = new Director()
			{
				Name = director.Name,
				DateOfBirth = director.DateOfBirth,
			};

			context.Directors.Add(directorNew);
			context.SaveChanges();
			return RedirectToAction("Index", "Director");
		}
		[HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Edit(int id)
		{

			var director = context.Directors.Find(id);
			if (director == null)
			{
				return RedirectToAction("Index", "Director");
			}
			var directorViewModel = new DirectorViewModel()
			{
				Name = director.Name,
				DateOfBirth= director.DateOfBirth,
			};
			ViewData["DirectorId"] = director.Id;
			return View(directorViewModel);
		}
		[HttpPost]
		public IActionResult Edit(int id, DirectorViewModel director)
		{
			var directors = context.Directors.Find(id);
			if (directors == null)
			{
				return RedirectToAction("Index", "Director");
			}

			if (!ModelState.IsValid)
			{
				ViewData["DirectorId"] = directors.Id;

				return View(director);
			}
			directors.Name = director.Name;
			directors.DateOfBirth = director.DateOfBirth;	
			context.SaveChanges();

			return RedirectToAction("Index", "Director");
		}
		[HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Delete(int id)
		{
			var director = context.Directors.Find(id);
			if (director == null)
			{
				return RedirectToAction("Index", "Director");
			}
			context.Directors.Remove(director);
			context.SaveChanges(true);
			return RedirectToAction("Index", "Director");
		}
	}
}
