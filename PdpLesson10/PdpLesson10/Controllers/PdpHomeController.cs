using Microsoft.AspNetCore.Mvc;
using PdpLesson10.Models;
using System.Diagnostics;
using PdpLesson10.Models;

namespace PdpLesson10EF.Controllers
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