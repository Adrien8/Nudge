using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nudge.Models;

namespace Nudge.Controllers
{
    public class TropheeController : Controller
    {
        private readonly NudgeContext _context;

        public TropheeController(NudgeContext context)
        {
            _context = context;
        }

        // GET: Trophee
        public async Task<IActionResult> Index()
        {
            var nudgeContext = _context.Trophee.Include(t => t.Defi).Include(t => t.Personne);
            return View(await nudgeContext.ToListAsync());
        }

        // GET: Trophee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trophee = await _context.Trophee
                .Include(t => t.Defi)
                .Include(t => t.Personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trophee == null)
            {
                return NotFound();
            }

            return View(trophee);
        }

        // GET: Trophee/Create
        public IActionResult Create()
        {
            ViewData["DefiId"] = new SelectList(_context.Set<Defi>(), "Id", "Intitule");
            ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom");
            return View();
        }

        // POST: Trophee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonneId,DefiId,NomTrophee")] Trophee trophee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trophee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DefiId"] = new SelectList(_context.Set<Defi>(), "Id", "Intitule", trophee.DefiId);
            ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom", trophee.PersonneId);
            return View(trophee);
        }

        // GET: Trophee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trophee = await _context.Trophee.FindAsync(id);
            if (trophee == null)
            {
                return NotFound();
            }
            
            ViewData["DefiId"] = new SelectList(_context.Set<Defi>(), "Id", "Intitule", trophee.DefiId);
            ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom", trophee.PersonneId);
            return View(trophee);
        }

        // POST: Trophee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonneId,DefiId,NomTrophee")] Trophee trophee)
        {
            if (id != trophee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trophee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TropheeExists(trophee.Id))
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
            ViewData["DefiId"] = new SelectList(_context.Set<Defi>(), "Id", "Intitule", trophee.DefiId);
            ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom", trophee.PersonneId);
            return View(trophee);
        }

        // GET: Trophee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trophee = await _context.Trophee
                .Include(t => t.Defi)
                .Include(t => t.Personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trophee == null)
            {
                return NotFound();
            }

            return View(trophee);
        }

        // POST: Trophee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trophee = await _context.Trophee.FindAsync(id);
            _context.Trophee.Remove(trophee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TropheeExists(int id)
        {
            return _context.Trophee.Any(e => e.Id == id);
        }
    }
}
