using Microsoft.AspNetCore.Mvc;

namespace PdpLesson.Controllers
{
    public class PdpHomeController : Controller
    {
        public IActionResult PdpIndex()
        {
            return View();
        }
    }
}
