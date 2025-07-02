using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PdpLesson11.Models;

namespace PdpLesson11.Controllers
{
    public class PdpHomeController : Controller
    {
        private readonly ILogger<PdpHomeController> _logger;

        public PdpHomeController(ILogger<PdpHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PdpIndex()
        {
            return View();
        }

        public IActionResult PdpAbout()
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
