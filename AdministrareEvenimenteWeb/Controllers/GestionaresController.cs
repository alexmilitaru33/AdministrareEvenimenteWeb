using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdministrareEvenimenteWeb.Models;

namespace AdministrareEvenimenteWeb.Controllers
{
    public class GestionaresController : Controller
    {
        private readonly ProiectContext _context;

        public GestionaresController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Gestionares
        public async Task<IActionResult> Index()
        {
            var proiectContext = _context.Gestionares.Include(g => g.IdEvenimentNavigation).Include(g => g.IdLocatieEvenimentNavigation);
            return View(await proiectContext.ToListAsync());
        }

        // GET: Gestionares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gestionares == null)
            {
                return NotFound();
            }

            var gestionare = await _context.Gestionares
                .Include(g => g.IdEvenimentNavigation)
                .Include(g => g.IdLocatieEvenimentNavigation)
                .FirstOrDefaultAsync(m => m.IdGestionare == id);
            if (gestionare == null)
            {
                return NotFound();
            }

            return View(gestionare);
        }

        // GET: Gestionares/Create
        public IActionResult Create()
        {
            ViewData["IdEveniment"] = new SelectList(_context.Eveniments, "IdEveniment", "IdEveniment");
            ViewData["IdLocatieEveniment"] = new SelectList(_context.LocatieEveniments, "IdLocatieEveniment", "IdLocatieEveniment");
            return View();
        }

        // POST: Gestionares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGestionare,IdEveniment,IdLocatieEveniment")] Gestionare gestionare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestionare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEveniment"] = new SelectList(_context.Eveniments, "IdEveniment", "IdEveniment", gestionare.IdEveniment);
            ViewData["IdLocatieEveniment"] = new SelectList(_context.LocatieEveniments, "IdLocatieEveniment", "IdLocatieEveniment", gestionare.IdLocatieEveniment);
            return View(gestionare);
        }

        // GET: Gestionares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gestionares == null)
            {
                return NotFound();
            }

            var gestionare = await _context.Gestionares.FindAsync(id);
            if (gestionare == null)
            {
                return NotFound();
            }
            ViewData["IdEveniment"] = new SelectList(_context.Eveniments, "IdEveniment", "IdEveniment", gestionare.IdEveniment);
            ViewData["IdLocatieEveniment"] = new SelectList(_context.LocatieEveniments, "IdLocatieEveniment", "IdLocatieEveniment", gestionare.IdLocatieEveniment);
            return View(gestionare);
        }

        // POST: Gestionares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGestionare,IdEveniment,IdLocatieEveniment")] Gestionare gestionare)
        {
            if (id != gestionare.IdGestionare)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestionare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestionareExists(gestionare.IdGestionare))
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
            ViewData["IdEveniment"] = new SelectList(_context.Eveniments, "IdEveniment", "IdEveniment", gestionare.IdEveniment);
            ViewData["IdLocatieEveniment"] = new SelectList(_context.LocatieEveniments, "IdLocatieEveniment", "IdLocatieEveniment", gestionare.IdLocatieEveniment);
            return View(gestionare);
        }

        // GET: Gestionares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gestionares == null)
            {
                return NotFound();
            }

            var gestionare = await _context.Gestionares
                .Include(g => g.IdEvenimentNavigation)
                .Include(g => g.IdLocatieEvenimentNavigation)
                .FirstOrDefaultAsync(m => m.IdGestionare == id);
            if (gestionare == null)
            {
                return NotFound();
            }

            return View(gestionare);
        }

        // POST: Gestionares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gestionares == null)
            {
                return Problem("Entity set 'ProiectContext.Gestionares'  is null.");
            }
            var gestionare = await _context.Gestionares.FindAsync(id);
            if (gestionare != null)
            {
                _context.Gestionares.Remove(gestionare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestionareExists(int id)
        {
          return (_context.Gestionares?.Any(e => e.IdGestionare == id)).GetValueOrDefault();
        }
    }
}
