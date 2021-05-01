using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLayerProject.MVCwithAPI.DTOs;
namespace NLayerProject.MVCwithAPI.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorDTO errorDTO)
        {
            return View(errorDTO);
        }
    }
}
