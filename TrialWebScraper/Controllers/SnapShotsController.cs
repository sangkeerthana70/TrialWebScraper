using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrialWebScraper.Models;

namespace TrialWebScraper.Controllers
{
    public class SnapShotsController : Controller
    {
        private readonly TrialWebScraperContext _context;

        public SnapShotsController(TrialWebScraperContext context)
        {
            _context = context;
        }

        // GET: SnapShots
        public async Task<IActionResult> Index()
        {
            return View(await _context.SnapShot.ToListAsync());
        }

        // GET: SnapShots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snapShot = await _context.SnapShot
                .SingleOrDefaultAsync(m => m.ID == id);
            if (snapShot == null)
            {
                return NotFound();
            }

            return View(snapShot);
        }

        // GET: SnapShots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SnapShots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserId,SnapShotTime")] SnapShot snapShot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snapShot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(snapShot);
        }

        // GET: SnapShots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snapShot = await _context.SnapShot.SingleOrDefaultAsync(m => m.ID == id);
            if (snapShot == null)
            {
                return NotFound();
            }
            return View(snapShot);
        }

        // POST: SnapShots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserId,SnapShotTime")] SnapShot snapShot)
        {
            if (id != snapShot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snapShot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnapShotExists(snapShot.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(snapShot);
        }

        // GET: SnapShots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snapShot = await _context.SnapShot
                .SingleOrDefaultAsync(m => m.ID == id);
            if (snapShot == null)
            {
                return NotFound();
            }

            return View(snapShot);
        }

        // POST: SnapShots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snapShot = await _context.SnapShot.SingleOrDefaultAsync(m => m.ID == id);
            _context.SnapShot.Remove(snapShot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnapShotExists(int id)
        {
            return _context.SnapShot.Any(e => e.ID == id);
        }
    }
}
