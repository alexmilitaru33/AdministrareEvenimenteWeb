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
    public class SediusController : Controller
    {
        private readonly ProiectContext _context;

        public SediusController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Sedius
        public async Task<IActionResult> Index()
        {
              return _context.Sedius != null ? 
                          View(await _context.Sedius.ToListAsync()) :
                          Problem("Entity set 'ProiectContext.Sedius'  is null.");
        }

        // GET: Sedius/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sedius == null)
            {
                return NotFound();
            }

            var sediu = await _context.Sedius
                .FirstOrDefaultAsync(m => m.IdSediu == id);
            if (sediu == null)
            {
                return NotFound();
            }

            return View(sediu);
        }

        // GET: Sedius/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sedius/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSediu,Judet,Localitate,Strada,Numar")] Sediu sediu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sediu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sediu);
        }

        // GET: Sedius/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sedius == null)
            {
                return NotFound();
            }

            var sediu = await _context.Sedius.FindAsync(id);
            if (sediu == null)
            {
                return NotFound();
            }
            return View(sediu);
        }

        // POST: Sedius/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSediu,Judet,Localitate,Strada,Numar")] Sediu sediu)
        {
            if (id != sediu.IdSediu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sediu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SediuExists(sediu.IdSediu))
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
            return View(sediu);
        }

        // GET: Sedius/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sedius == null)
            {
                return NotFound();
            }

            var sediu = await _context.Sedius
                .FirstOrDefaultAsync(m => m.IdSediu == id);
            if (sediu == null)
            {
                return NotFound();
            }

            return View(sediu);
        }

        // POST: Sedius/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sedius == null)
            {
                return Problem("Entity set 'ProiectContext.Sedius'  is null.");
            }
            var sediu = await _context.Sedius.FindAsync(id);
            if (sediu != null)
            {
                _context.Sedius.Remove(sediu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SediuExists(int id)
        {
          return (_context.Sedius?.Any(e => e.IdSediu == id)).GetValueOrDefault();
        }
    }
}
