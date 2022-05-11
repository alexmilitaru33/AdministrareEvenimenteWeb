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
    public class ServiciisController : Controller
    {
        private readonly ProiectContext _context;

        public ServiciisController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Serviciis
        public async Task<IActionResult> Index()
        {
              return _context.Serviciis != null ? 
                          View(await _context.Serviciis.ToListAsync()) :
                          Problem("Entity set 'ProiectContext.Serviciis'  is null.");
        }

        // GET: Serviciis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Serviciis == null)
            {
                return NotFound();
            }

            var servicii = await _context.Serviciis
                .FirstOrDefaultAsync(m => m.IdServicii == id);
            if (servicii == null)
            {
                return NotFound();
            }

            return View(servicii);
        }

        // GET: Serviciis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Serviciis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicii,NumeServiciu,PretServiciu")] Servicii servicii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicii);
        }

        // GET: Serviciis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Serviciis == null)
            {
                return NotFound();
            }

            var servicii = await _context.Serviciis.FindAsync(id);
            if (servicii == null)
            {
                return NotFound();
            }
            return View(servicii);
        }

        // POST: Serviciis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicii,NumeServiciu,PretServiciu")] Servicii servicii)
        {
            if (id != servicii.IdServicii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiciiExists(servicii.IdServicii))
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
            return View(servicii);
        }

        // GET: Serviciis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Serviciis == null)
            {
                return NotFound();
            }

            var servicii = await _context.Serviciis
                .FirstOrDefaultAsync(m => m.IdServicii == id);
            if (servicii == null)
            {
                return NotFound();
            }

            return View(servicii);
        }

        // POST: Serviciis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Serviciis == null)
            {
                return Problem("Entity set 'ProiectContext.Serviciis'  is null.");
            }
            var servicii = await _context.Serviciis.FindAsync(id);
            if (servicii != null)
            {
                _context.Serviciis.Remove(servicii);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciiExists(int id)
        {
          return (_context.Serviciis?.Any(e => e.IdServicii == id)).GetValueOrDefault();
        }
    }
}
