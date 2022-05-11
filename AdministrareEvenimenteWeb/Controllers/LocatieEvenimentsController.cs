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
    public class LocatieEvenimentsController : Controller
    {
        private readonly ProiectContext _context;

        public LocatieEvenimentsController(ProiectContext context)
        {
            _context = context;
        }

        // GET: LocatieEveniments
        public async Task<IActionResult> Index()
        {
              return _context.LocatieEveniments != null ? 
                          View(await _context.LocatieEveniments.ToListAsync()) :
                          Problem("Entity set 'ProiectContext.LocatieEveniments'  is null.");
        }

        // GET: LocatieEveniments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocatieEveniments == null)
            {
                return NotFound();
            }

            var locatieEveniment = await _context.LocatieEveniments
                .FirstOrDefaultAsync(m => m.IdLocatieEveniment == id);
            if (locatieEveniment == null)
            {
                return NotFound();
            }

            return View(locatieEveniment);
        }

        // GET: LocatieEveniments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocatieEveniments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocatieEveniment,NumeLocatie,Judet,Localitate,Strada,Numar")] LocatieEveniment locatieEveniment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locatieEveniment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locatieEveniment);
        }

        // GET: LocatieEveniments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LocatieEveniments == null)
            {
                return NotFound();
            }

            var locatieEveniment = await _context.LocatieEveniments.FindAsync(id);
            if (locatieEveniment == null)
            {
                return NotFound();
            }
            return View(locatieEveniment);
        }

        // POST: LocatieEveniments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocatieEveniment,NumeLocatie,Judet,Localitate,Strada,Numar")] LocatieEveniment locatieEveniment)
        {
            if (id != locatieEveniment.IdLocatieEveniment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locatieEveniment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocatieEvenimentExists(locatieEveniment.IdLocatieEveniment))
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
            return View(locatieEveniment);
        }

        // GET: LocatieEveniments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LocatieEveniments == null)
            {
                return NotFound();
            }

            var locatieEveniment = await _context.LocatieEveniments
                .FirstOrDefaultAsync(m => m.IdLocatieEveniment == id);
            if (locatieEveniment == null)
            {
                return NotFound();
            }

            return View(locatieEveniment);
        }

        // POST: LocatieEveniments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LocatieEveniments == null)
            {
                return Problem("Entity set 'ProiectContext.LocatieEveniments'  is null.");
            }
            var locatieEveniment = await _context.LocatieEveniments.FindAsync(id);
            if (locatieEveniment != null)
            {
                _context.LocatieEveniments.Remove(locatieEveniment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatieEvenimentExists(int id)
        {
          return (_context.LocatieEveniments?.Any(e => e.IdLocatieEveniment == id)).GetValueOrDefault();
        }
    }
}
