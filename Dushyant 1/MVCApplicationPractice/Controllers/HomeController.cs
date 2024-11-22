using Microsoft.AspNetCore.Mvc;
using MVCApplicationPractice.Models;
using System.Diagnostics;

namespace MVCApplicationPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["CompanyName"] = "Microsoft";
            TempData["Role"] = "Full Stack Developer";
            TempData["Age"] = 24;
            return View();
        }

        public IActionResult Privacy()
        {
            var value = TempData.Peek("Age");
            return View();
        }
        public IActionResult Test1()
        {
            ViewData["Name"] = ".NET CORE ";
            ViewBag.Occupation = "Developer";   
            return View();
        }
        public IActionResult Test2()
        {
            ViewData["Name"] = ".Java ";
            ViewData["Occupation"] = "java Developer ";
            ViewData["Skills"] = "Java Spring Boot ";
            return View();
        }
        public IActionResult Test3()
        {
            ViewBag.Name = "Python";
            ViewBag.Skills = "Python Flask , Mongo DB";
            ViewBag.Occupation = " Python  Developer";

            return View();
        }
        public IActionResult Test4()
        {

            ViewData["Name"] = "MERN ";
            ViewData["Occupation"] = "MERN Developer ";
            ViewBag.Skills = "Python Flask , Mongo DB";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
