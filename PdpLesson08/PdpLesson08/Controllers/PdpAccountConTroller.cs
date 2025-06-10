using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdpLesson08Annotation.Models;

namespace PdpLesson08Annotation.Controllers
{
    public class PdpAccountController : Controller
    {
        private static List<PdpAccount> pdpListAccount = new List<PdpAccount>()
        {
            new PdpAccount { PdpId = 230022113, PdpFullName = "Phạm Đình Phùng", PdpEmail = "phamdinhphung79@gmail.com", PdpPhone = "0373866467", PdpAddress = "Lớp K23CNT3", PdpAvatar = "phamphung.jpg", PdpBirthday = new DateTime(2005, 9, 7), PdpGender = "Nam", PdpPassword = "0373866467", PdpFacebook = "https://www.facebook.com/share/16LsaY8L5w/" },
            new PdpAccount { PdpId = 2, PdpFullName = "Vũ Thị Hồng Hạnh", PdpEmail = "hanh01@gmail.com", PdpPhone = "0987654321", PdpAddress = "xom3", PdpAvatar = "avatar2.jpg", PdpBirthday = new DateTime(2007, 1, 1), PdpGender = "Nữ", PdpPassword = "password2", PdpFacebook = "https://www.facebook.com/share/1Bpg89CUgT/?mibextid=wwXIfr" },
            new PdpAccount { PdpId = 3, PdpFullName = "Lê Văn C", PdpEmail = "levanc@example.com", PdpPhone = "0911222333", PdpAddress = "789 Đường C", PdpAvatar = "avatar3.jpg", PdpBirthday = new DateTime(1988, 12, 1), PdpGender = "Nam", PdpPassword = "password3", PdpFacebook = "https://facebook.com/levanc" },
            new PdpAccount { PdpId = 4, PdpFullName = "Phạm Thị D", PdpEmail = "phamthid@example.com", PdpPhone = "0909876543", PdpAddress = "321 Đường D", PdpAvatar = "avatar4.jpg", PdpBirthday = new DateTime(1995, 3, 10), PdpGender = "Nữ", PdpPassword = "password4", PdpFacebook = "https://facebook.com/phamthid" },
            new PdpAccount { PdpId = 5, PdpFullName = "Hoàng Văn E", PdpEmail = "hoangvane@example.com", PdpPhone = "0933444555", PdpAddress = "654 Đường E", PdpAvatar = "avatar5.jpg", PdpBirthday = new DateTime(1991, 7, 22), PdpGender = "Nam", PdpPassword = "password5", PdpFacebook = "https://facebook.com/hoangvane" }
        };

        // GET: PdpAccountController
        public ActionResult PdpIndex()
        {
            return View(pdpListAccount);
        }

        // GET: PdpAccountController/Details/5
        public ActionResult Details(int id)
        {
            var acc = pdpListAccount.FirstOrDefault(x => x.PdpId == id);
            if (acc == null) return NotFound();
            return View(acc);
        }

        // GET: PdpAccountController/PdpCreate
        public ActionResult PdpCreate()
        {
            return View(new PdpAccount());
        }

        // POST: PdpAccountController/PdpCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PdpCreate(PdpAccount model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.PdpId = pdpListAccount.Max(x => x.PdpId) + 1;
                    pdpListAccount.Add(model);
                    return RedirectToAction("PdpIndex");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi: " + ex.Message);
                return View(model);
            }
        }

        // GET: PdpAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            var acc = pdpListAccount.FirstOrDefault(x => x.PdpId == id);
            if (acc == null) return NotFound();
            return View(acc);
        }

        // POST: PdpAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PdpAccount model)
        {
            try
            {
                var acc = pdpListAccount.FirstOrDefault(x => x.PdpId == id);
                if (acc == null) return NotFound();

                // Cập nhật thủ công
                acc.PdpFullName = model.PdpFullName;
                acc.PdpEmail = model.PdpEmail;
                acc.PdpPhone = model.PdpPhone;
                acc.PdpAddress = model.PdpAddress;
                acc.PdpAvatar = model.PdpAvatar;
                acc.PdpBirthday = model.PdpBirthday;
                acc.PdpGender = model.PdpGender;
                acc.PdpPassword = model.PdpPassword;
                acc.PdpFacebook = model.PdpFacebook;

                return RedirectToAction("PdpIndex");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: PdpAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var acc = pdpListAccount.FirstOrDefault(x => x.PdpId == id);
            if (acc == null) return NotFound();
            return View(acc);
        }

        // POST: PdpAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var acc = pdpListAccount.FirstOrDefault(x => x.PdpId == id);
                if (acc != null)
                    pdpListAccount.Remove(acc);
                return RedirectToAction("PdpIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
