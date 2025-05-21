using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PdpLesson05.Models;

namespace PdpLesson05.Controllers
{
    public class PdpHomeController : Controller
    {
        private readonly ILogger<PdpHomeController> _logger;

        public PdpHomeController(ILogger<PdpHomeController> logger)
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
