using Microsoft.AspNetCore.Mvc;
using Pdplesson06.Models;

namespace Pdplesson06.Controllers
{
    public class PdpEmployeeController : Controller
    {
        static List<PdpEmployee> PdpListEmployee = new List<PdpEmployee>
        {
            new PdpEmployee { PdpId = 1, PdpName = "Phạm Đình Phùng", PdpBirthDay = new DateTime(2005,9,7), PdpEmail = "phamdinhphung79@gmail.com", PdpPhone = "0373866467", PdpSalary = 100000000, PdpStatus = true },
            new PdpEmployee { PdpId = 2, PdpName = "Vũ Thị Hồng Hạnh", PdpBirthDay = new DateTime(2007,1,1), PdpEmail = "hanh99@gmail.com", PdpPhone = "0902222222", PdpSalary = 6500, PdpStatus = true },
            new PdpEmployee { PdpId = 3, PdpName = "Lê Văn C", PdpBirthDay = new DateTime(1998,3,3), PdpEmail = "c@gmail.com", PdpPhone = "0903333333", PdpSalary = 7000, PdpStatus = false },
            new PdpEmployee { PdpId = 4, PdpName = "Phạm Thị D", PdpBirthDay = new DateTime(1997,4,4), PdpEmail = "d@gmail.com", PdpPhone = "0904444444", PdpSalary = 5500, PdpStatus = true },
            new PdpEmployee { PdpId = 5, PdpName = "Nguyễn Sinh Viên", PdpBirthDay = new DateTime(2003,5,5), PdpEmail = "sv@gmail.com", PdpPhone = "0905555555", PdpSalary = 8000, PdpStatus = true }
        };

        public IActionResult PdpIndex() => View(PdpListEmployee);

        public IActionResult PdpCreate() => View();

        [HttpPost]
        public IActionResult PdpCreateSubmit(PdpEmployee emp)
        {
            emp.PdpId = PdpListEmployee.Max(e => e.PdpId) + 1;
            PdpListEmployee.Add(emp);
            return RedirectToAction("PdpIndex");
        }

        public IActionResult PdpEdit(int id)
        {
            var emp = PdpListEmployee.FirstOrDefault(e => e.PdpId == id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult PdpEditPUT(PdpEmployee emp)
        {
            var item = PdpListEmployee.FirstOrDefault(e => e.PdpId == emp.PdpId);
            if (item != null)
            {
                item.PdpName = emp.PdpName;
                item.PdpBirthDay = emp.PdpBirthDay;
                item.PdpEmail = emp.PdpEmail;
                item.PdpPhone = emp.PdpPhone;
                item.PdpSalary = emp.PdpSalary;
                item.PdpStatus = emp.PdpStatus;
            }
            return RedirectToAction("PdpIndex");
        }

        public IActionResult PdpDelete(int id)
        {
            var emp = PdpListEmployee.FirstOrDefault(e => e.PdpId == id);
            if (emp != null) PdpListEmployee.Remove(emp);
            return RedirectToAction("PdpIndex");
        }
    }
}
