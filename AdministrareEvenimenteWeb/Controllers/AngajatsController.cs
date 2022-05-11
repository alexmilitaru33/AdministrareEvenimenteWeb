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
    public class AngajatsController : Controller
    {
        private readonly ProiectContext _context;

        public AngajatsController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Angajats
        public async Task<IActionResult> Index(string sortOrder = "")
        {
            ViewBag.NumeSortParm = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            ViewBag.PrenumeSortParm = sortOrder == "prenume" ? "prenume_desc" : "prenume";
            var angajati = from s in _context.Angajats
                           select s;
            switch (sortOrder)
            {
                case "nume_desc":
                    angajati = angajati.OrderByDescending(s => s.Nume);
                    break;
                case "prenume_desc":
                    angajati = angajati.OrderByDescending(s => s.Prenume);
                    break;
                case "prenume":
                    angajati = angajati.OrderBy(s => s.Prenume);
                    break;
                default:
                    angajati = angajati.OrderBy(s => s.Nume);
                    break;
            }
            return View(await angajati.ToListAsync());
            //var proiectContext = _context.Angajats.Include(a => a.IdSediuNavigation).Include(a => a.IdServiciiNavigation);
            //return View();
        } 

        // GET: Angajats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Angajats == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajats
                .Include(a => a.IdSediuNavigation)
                .Include(a => a.IdServiciiNavigation)
                .FirstOrDefaultAsync(m => m.IdAngajat == id);
            if (angajat == null)
            {
                return NotFound();
            }

            return View(angajat);
        }

        // GET: Angajats/Create
        public IActionResult Create()
        {
            ViewData["IdSediu"] = new SelectList(_context.Sedius, "IdSediu", "IdSediu");
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii");
            return View();
        }

        // POST: Angajats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAngajat,Nume,Prenume,Email,Telefon,IdSediu,IdServicii")] Angajat angajat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(angajat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSediu"] = new SelectList(_context.Sedius, "IdSediu", "IdSediu", angajat.IdSediu);
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii", angajat.IdServicii);
            return View(angajat);
        }

        // GET: Angajats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Angajats == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajats.FindAsync(id);
            if (angajat == null)
            {
                return NotFound();
            }
            ViewData["IdSediu"] = new SelectList(_context.Sedius, "IdSediu", "IdSediu", angajat.IdSediu);
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii", angajat.IdServicii);
            return View(angajat);
        }

        // POST: Angajats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAngajat,Nume,Prenume,Email,Telefon,IdSediu,IdServicii")] Angajat angajat)
        {
            if (id != angajat.IdAngajat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(angajat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AngajatExists(angajat.IdAngajat))
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
            ViewData["IdSediu"] = new SelectList(_context.Sedius, "IdSediu", "IdSediu", angajat.IdSediu);
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii", angajat.IdServicii);
            return View(angajat);
        }

        // GET: Angajats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Angajats == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajats
                .Include(a => a.IdSediuNavigation)
                .Include(a => a.IdServiciiNavigation)
                .FirstOrDefaultAsync(m => m.IdAngajat == id);
            if (angajat == null)
            {
                return NotFound();
            }

            return View(angajat);
        }

        // POST: Angajats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Angajats == null)
            {
                return Problem("Entity set 'ProiectContext.Angajats'  is null.");
            }
            var angajat = await _context.Angajats.FindAsync(id);
            if (angajat != null)
            {
                _context.Angajats.Remove(angajat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AngajatExists(int id)
        {
          return (_context.Angajats?.Any(e => e.IdAngajat == id)).GetValueOrDefault();
        }
    }
}
