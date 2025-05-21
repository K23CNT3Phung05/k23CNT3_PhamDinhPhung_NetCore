using Microsoft.AspNetCore.Mvc;
using PdpLesson5.Models;

namespace PdpLesson5.Controllers
{
    public class PdpMemberController : Controller
    {
        public static readonly List<PdpMember> Members = new List<PdpMember>()
        {
            new PdpMember { id = Guid.NewGuid().ToString("N"), PdpName = "Pham Dinh Phung", PdpPassword = "123456@", PdpEmail = "Pdp30000@gmail.com" },
            new PdpMember { id = Guid.NewGuid().ToString("N"), PdpName = "Lê Quang Liêm", PdpPassword = "masterchess123", PdpEmail = "liemchessking102@gmail.com" },
            new PdpMember { id = Guid.NewGuid().ToString("N"), PdpName = "Trịnh Trần Kim", PdpPassword = "Bokachan97", PdpEmail = "kimcobon123@gmail.com" },
            new PdpMember { id = Guid.NewGuid().ToString("N"), PdpName = "Nguyễn Ngọc Anh", PdpPassword = "bombtowin123", PdpEmail = "anhmaster102@gmail.com" },
            new PdpMember { id = Guid.NewGuid().ToString("N"), PdpName = "Lê Thị Nhi", PdpPassword = "zuka123netc", PdpEmail = "nhi12@gmail.com" }
        };

        public IActionResult PdpIndex()
        {
            return View(Members);
        }
    }
}