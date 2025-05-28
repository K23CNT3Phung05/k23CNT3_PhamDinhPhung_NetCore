using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pdplesson06.Models;

namespace Pdplesson06.Controllers
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

        public IActionResult PdpAbout()
        {
            ViewBag.StudentName = "Phạm Đình Phùng";
            ViewBag.StudentID = "231090083";
            ViewBag.Class = "CNTT3";
            ViewBag.Quote = "“Học để biết, học để làm, học để chung sống và học để tự khẳng định mình.”";
            return View();
        }
    }
}
