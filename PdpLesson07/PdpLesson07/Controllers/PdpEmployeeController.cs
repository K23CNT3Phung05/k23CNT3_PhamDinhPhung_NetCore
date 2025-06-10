using Microsoft.AspNetCore.Mvc;
using Pdplesson07.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pdplesson07.Controllers
{
    public class PdpEmployeeController : Controller
    {
        // Mock Data - Danh sách nhân viên
        private static List<PdpEmployee> PdpListEmployee = new List<PdpEmployee>
        {
            new PdpEmployee { PdpId = 1, PdpName = "Phạm Đình Phùng", PdpBirthDay = new DateTime(2005,9,7), PdpEmail = "phamdinhphung79@gmail.com", PdpPhone = "0373866467", PdpSalary = 100000000, PdpStatus = true },
            new PdpEmployee { PdpId = 2, PdpName = "Vũ Thị Hồng Hạnh", PdpBirthDay = new DateTime(2007,1,1), PdpEmail = "hanh99@gmail.com", PdpPhone = "0902222222", PdpSalary = 6500, PdpStatus = true },
            new PdpEmployee { PdpId = 3, PdpName = "Lê Văn C", PdpBirthDay = new DateTime(1998, 3, 3), PdpEmail = "c@gmail.com", PdpPhone = "0903333333", PdpSalary = 7000, PdpStatus = false }
        };

        // Hiển thị danh sách nhân viên
        public IActionResult PdpIndex()
        {
            return View(PdpListEmployee);
        }

        // Hiển thị chi tiết nhân viên
        public IActionResult Details(int id)
        {
            var emp = PdpListEmployee.FirstOrDefault(e => e.PdpId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // GET: Hiển thị form tạo mới
        public IActionResult PdpCreate()
        {
            return View();
        }

        // POST: Xử lý dữ liệu tạo mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PdpCreate(PdpEmployee pdp)
        {
            if (ModelState.IsValid)
            {
                pdp.PdpId = PdpListEmployee.Max(e => e.PdpId) + 1;
                PdpListEmployee.Add(pdp);
                return RedirectToAction(nameof(PdpIndex));
            }
            return View(pdp);
        }

        // GET: Hiển thị form chỉnh sửa
        public IActionResult PdpEdit(int id)
        {
            var emp = PdpListEmployee.FirstOrDefault(e => e.PdpId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: Xử lý cập nhật nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PdpEdit(int id, PdpEmployee pdp)
        {
            if (id != pdp.PdpId) return BadRequest();

            if (ModelState.IsValid)
            {
                var emp = PdpListEmployee.FirstOrDefault(e => e.PdpId == id);
                if (emp == null) return NotFound();

                emp.PdpName = pdp.PdpName;
                emp.PdpBirthDay = pdp.PdpBirthDay;
                emp.PdpEmail = pdp.PdpEmail;
                emp.PdpPhone = pdp.PdpPhone;
                emp.PdpSalary = pdp.PdpSalary;
                emp.PdpStatus = pdp.PdpStatus;

                return RedirectToAction(nameof(PdpIndex));
            }
            return View(pdp);
        }

        // GET: Hiển thị xác nhận xóa
        public IActionResult PdpCreate(int id)
        {
            var emp = PdpListEmployee.FirstOrDefault(e => e.PdpId == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: Xác nhận xóa nhân viên
        [HttpPost, ActionName("PdpCreate")]
        [ValidateAntiForgeryToken]
        public IActionResult PdpCreateConfirmed(int id)
        {
            var emp = PdpListEmployee.FirstOrDefault(e => e.PdpId == id);
            if (emp != null)
            {
                PdpListEmployee.Remove(emp);
            }
            return RedirectToAction(nameof(PdpIndex));
        }
    }
}
