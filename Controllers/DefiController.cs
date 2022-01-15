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
    public class DefiController : Controller
    {
        private readonly NudgeContext _context;

        public DefiController(NudgeContext context)
        {
            _context = context;
        }

        // GET: Defi
        public async Task<IActionResult> Index()
        {
            var mvcTacheContext = _context.Defi.Include(d => d.Personne);
            return View(await mvcTacheContext.ToListAsync());
        }

        // GET: Defi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defi = await _context.Defi
                .Include(d => d.Personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defi == null)
            {
                return NotFound();
            }

            return View(defi);
        }

        // GET: Defi/Create
        public IActionResult Create()
        {
            ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom");
            return View();
        }

        // POST: Defi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonneId,Intitule,Commentaire,Theme,DateDebut,DateFin,Progression,Reussite,TousLesJours,Repetition")] Defi defi)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
/*
            if (ModelState.IsValid)
            {*/
                ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom", defi.PersonneId);

                _context.Add(defi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          //  }
            //return RedirectToAction(nameof(Index));
        }

        // GET: Defi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defi = await _context.Defi.FindAsync(id);
            if (defi == null)
            {
                return NotFound();
            }
            ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom", defi.PersonneId);
            return View(defi);
        }

        // POST: Defi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonneId,Intitule,Commentaire,Theme,DateDebut,DateFin,Progression,Reussite,TousLesJours,Repetition")] Defi defi)
        {
            if (id != defi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefiExists(defi.Id))
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
            ViewData["PersonneId"] = new SelectList(_context.Personne, "Id", "Prenom", defi.PersonneId);
            return View(defi);
        }

        // GET: Defi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defi = await _context.Defi
                .Include(d => d.Personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defi == null)
            {
                return NotFound();
            }

            return View(defi);
        }

        // POST: Defi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defi = await _context.Defi.FindAsync(id);
            _context.Defi.Remove(defi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefiExists(int id)
        {
            return _context.Defi.Any(e => e.Id == id);
        }
    }
}
