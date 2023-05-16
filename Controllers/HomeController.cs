using Microsoft.AspNetCore.Mvc;
using OMDB_API.Models;
using System.Diagnostics;

namespace OMDB_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MovieDAL moviesAPI = new MovieDAL();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult MovieSearchForm()
        {
            return View("MovieSearch");
        }
        [HttpPost]
        public IActionResult MovieSearchResults(string title) 
        {
            Movie m = moviesAPI.GetMovie(title);
            return View("MovieSearch",m);
        }
        [HttpGet]
        public IActionResult MovieNightForm()
        {
            return View("MovieNight");
        }
        public IActionResult MovieNightResult(string title1, string title2, string title3) 
        {
            Movie m1 = moviesAPI.GetMovie(title1);
            Movie m2 = moviesAPI.GetMovie(title2);
            Movie m3 = moviesAPI.GetMovie(title3);
            List<Movie> movies = new List<Movie>() { m1, m2, m3};

            return View("MovieNight", movies);
        }
        public IActionResult Index()
        {
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