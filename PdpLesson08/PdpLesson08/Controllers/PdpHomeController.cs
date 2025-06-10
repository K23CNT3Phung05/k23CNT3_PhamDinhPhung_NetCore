using Microsoft.AspNetCore.Mvc;
using PdpLesson08.Models;
using PdpLesson08Annotation.Models;
using System.Diagnostics;

namespace PdpLesson08Annotation.Controllers
{
    public class PdpHomeController : Controller
    {
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
