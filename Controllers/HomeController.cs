using KhumaloCraftsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace KhumaloCraftsWebApp.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult MyWork()
        {
            
            var craftworkList = new List<CraftWork>
        {
            new CraftWork { Id = 1, Name = "Handcrafted Mug", Description = "Beautifully handcrafted ceramic mug", ImageUrl = "/images/mug.jpg", Price = 200.00m },
            new CraftWork { Id = 2, Name = "Handwoven Basket", Description = "Traditional handwoven basket made from natural fibers", ImageUrl = "/images/basket.jpg", Price = 100.00m },
            new CraftWork { Id = 3, Name = "Handmade Necklace", Description = "Unique beaded necklace crafted by local artisans", ImageUrl = "/images/necklace.jpg", Price = 50.00m },
        };

            return View(craftworkList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
