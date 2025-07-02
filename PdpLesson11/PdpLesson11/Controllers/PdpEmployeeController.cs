using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhamDinhPhung_2310900083.Models;

namespace PhamDinhPhung2310900083.Controllers
{
    public class PdpEmployeeController : Controller
    {
        private readonly PhamDinhPhung2310900083Context _context;

        public PdpEmployeeController(PhamDinhPhung2310900083Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> PdpIndex()
        {
            return View(await _context.PdpEmployees.ToListAsync());
        }

        public async Task<IActionResult> PdpDetails(int? PdpId)
        {
            if (PdpId == null) return NotFound();
            var emp = await _context.PdpEmployees.FirstOrDefaultAsync(m => m.PdpEmpId == PdpId);
            return emp == null ? NotFound() : View(emp);
        }

        public IActionResult PdpCreate() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdpCreate(PdpEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PdpIndex));
            }
            return View(emp);
        }

        public async Task<IActionResult> PdpEdit(int? PdpId)
        {
            if (PdpId == null) return NotFound();
            var emp = await _context.PdpEmployees.FindAsync(PdpId);
            return emp == null ? NotFound() : View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdpEdit(int PdpId, PdpEmployee emp)
        {
            if (PdpId != emp.PdpEmpId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PdpEmployees.Any(e => e.PdpEmpId == emp.PdpEmpId))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(PdpIndex));
            }
            return View(emp);
        }

        public async Task<IActionResult> PdpDelete(int? PdpId)
        {
            if (PdpId == null) return NotFound();
            var emp = await _context.PdpEmployees.FirstOrDefaultAsync(m => m.PdpEmpId == PdpId);
            return emp == null ? NotFound() : View(emp);
        }

        [HttpPost, ActionName("PdpDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdpDeleteConfirmed(int PdpId)
        {
            var emp = await _context.PdpEmployees.FindAsync(PdpId);
            if (emp != null)
            {
                _context.PdpEmployees.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(PdpIndex));
        }
    }
}