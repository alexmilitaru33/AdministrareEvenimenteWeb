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
    public class EvenimentsController : Controller
    {
        private readonly ProiectContext _context;

        public EvenimentsController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Eveniments
        public async Task<IActionResult> Index()
        {
            var proiectContext = _context.Eveniments.Include(e => e.IdClientNavigation);
            return View(await proiectContext.ToListAsync());
        }

        // GET: Eveniments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eveniments == null)
            {
                return NotFound();
            }

            var eveniment = await _context.Eveniments
                .Include(e => e.IdClientNavigation)
                .FirstOrDefaultAsync(m => m.IdEveniment == id);
            if (eveniment == null)
            {
                return NotFound();
            }

            return View(eveniment);
        }

        // GET: Eveniments/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient");
            return View();
        }

        // POST: Eveniments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEveniment,NumeEveniment,DataOraInceperii,DataOraIncheierii,IdClient")] Eveniment eveniment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eveniment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient", eveniment.IdClient);
            return View(eveniment);
        }

        // GET: Eveniments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eveniments == null)
            {
                return NotFound();
            }

            var eveniment = await _context.Eveniments.FindAsync(id);
            if (eveniment == null)
            {
                return NotFound();
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient", eveniment.IdClient);
            return View(eveniment);
        }

        // POST: Eveniments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEveniment,NumeEveniment,DataOraInceperii,DataOraIncheierii,IdClient")] Eveniment eveniment)
        {
            if (id != eveniment.IdEveniment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eveniment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenimentExists(eveniment.IdEveniment))
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
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "IdClient", eveniment.IdClient);
            return View(eveniment);
        }

        // GET: Eveniments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eveniments == null)
            {
                return NotFound();
            }

            var eveniment = await _context.Eveniments
                .Include(e => e.IdClientNavigation)
                .FirstOrDefaultAsync(m => m.IdEveniment == id);
            if (eveniment == null)
            {
                return NotFound();
            }

            return View(eveniment);
        }

        // POST: Eveniments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eveniments == null)
            {
                return Problem("Entity set 'ProiectContext.Eveniments'  is null.");
            }
            var eveniment = await _context.Eveniments.FindAsync(id);
            if (eveniment != null)
            {
                _context.Eveniments.Remove(eveniment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenimentExists(int id)
        {
          return (_context.Eveniments?.Any(e => e.IdEveniment == id)).GetValueOrDefault();
        }
    }
}
