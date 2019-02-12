using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPCoreMVC_01.Models;
using NorthwindLibrary;

namespace ASPCoreMVC_01.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindEntities db;

        public HomeController(NorthwindEntities injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
