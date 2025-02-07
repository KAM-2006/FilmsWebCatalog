using FilmsWebCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilmsWebCatalog.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
