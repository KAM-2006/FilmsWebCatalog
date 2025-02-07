using FilmsWebCatalog.Data;
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
    }
}
