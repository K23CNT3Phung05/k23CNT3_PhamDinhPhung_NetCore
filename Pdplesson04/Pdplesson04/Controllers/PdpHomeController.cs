using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PdpLesson4.Models;

namespace PdpLesson4.Controllers
{
    public class PdpHomeController : Controller // Sửa PdpController thành Controller
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

        public IActionResult PdpPrivacy()
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
