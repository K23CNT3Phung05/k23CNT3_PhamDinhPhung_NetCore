using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdpLesson10.Models;

namespace PdpLesson10.Controllers
{
    public class PdpPostsController : Controller
    {
        private readonly PdpK23cnt3lesson10DbContext _context;

        public PdpPostsController(PdpK23cnt3lesson10DbContext context)
        {
            _context = context;
        }

        // GET: PdpPosts
        public async Task<IActionResult> PdpIndex()
        {
            return View(await _context.PdpPosts.ToListAsync());
        }

        // GET: PdpPosts/PdpDetails/5
        public async Task<IActionResult> PdpDetails(int? PdpId)
        {
            if (PdpId == null)
            {
                return NotFound();
            }

            var PdpPosts = await _context.PdpPosts
                .FirstOrDefaultAsync(m => m.PdpId == PdpId);
            if (PdpPosts == null)
            {
                return NotFound();
            }

            return View(PdpPosts);
        }

        // GET: PdpPosts/PdpCreate
        public IActionResult PdpCreate()
        {
            return View();
        }

        // POST: PdpPosts/PdpCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdpCreate([Bind("PdpId,PdpTitle,PdpImage,PdpContent,PdpStatus")] PdpPosts PdpPosts, IFormFile PdpImage)
        {
            if (ModelState.IsValid)
            {
                if (PdpImage != null && PdpImage.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(PdpImage.FileName);
                    var extension = Path.GetExtension(PdpImage.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await PdpImage.CopyToAsync(stream);
                    }

                    PdpPosts.PdpImage = "images/" + newFileName;
                }

                _context.Add(PdpPosts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PdpIndex));
            }
            return View(PdpPosts);
        }

        // GET: PdpPosts/PdpEdit/5
        public async Task<IActionResult> PdpEdit(int? PdpId)
        {
            if (PdpId == null)
            {
                return NotFound();
            }

            var PdpPosts = await _context.PdpPosts.FindAsync(PdpId);
            if (PdpPosts == null)
            {
                return NotFound();
            }

            return View(PdpPosts);
        }

        // POST: PdpPosts/PdpEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdpEdit(int PdpId, [Bind("PdpId,PdpTitle,PdpImage,PdpContent,PdpStatus")] PdpPosts PdpPosts, IFormFile PdpImage)
        {
            if (PdpId != PdpPosts.PdpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (PdpImage != null && PdpImage.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(PdpImage.FileName);
                    var extension = Path.GetExtension(PdpImage.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await PdpImage.CopyToAsync(stream);
                    }

                    PdpPosts.PdpImage = "images/" + newFileName;
                }

                try
                {
                    _context.Update(PdpPosts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdpPostsExists(PdpPosts.PdpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(PdpIndex));
            }

            return View(PdpPosts);
        }

        // GET: PdpPosts/PdpDelete/5
        public async Task<IActionResult> PdpDelete(int? PdpId)
        {
            if (PdpId == null)
            {
                return NotFound();
            }

            var PdpPosts = await _context.PdpPosts
                .FirstOrDefaultAsync(m => m.PdpId == PdpId);
            if (PdpPosts == null)
            {
                return NotFound();
            }

            return View(PdpPosts);
        }

        // POST: PdpPosts/PdpDelete/5
        [HttpPost, ActionName("PdpDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int PdpId)
        {
            var PdpPosts = await _context.PdpPosts.FindAsync(PdpId);
            if (PdpPosts != null)
            {
                _context.PdpPosts.Remove(PdpPosts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PdpIndex));
        }

        private bool PdpPostsExists(int id)
        {
            return _context.PdpPosts.Any(e => e.PdpId == id);
        }
    }
}
