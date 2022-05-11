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
    public class AdministreazasController : Controller
    {
        private readonly ProiectContext _context;

        public AdministreazasController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Administreazas
        public async Task<IActionResult> Index()
        {
            var proiectContext = _context.Administreazas.Include(a => a.IdModelNavigation).Include(a => a.IdServiciiNavigation);
            return View(await proiectContext.ToListAsync());
        }

        // GET: Administreazas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Administreazas == null)
            {
                return NotFound();
            }

            var administreaza = await _context.Administreazas
                .Include(a => a.IdModelNavigation)
                .Include(a => a.IdServiciiNavigation)
                .FirstOrDefaultAsync(m => m.IdAdministreaza == id);
            if (administreaza == null)
            {
                return NotFound();
            }

            return View(administreaza);
        }

        // GET: Administreazas/Create
        public IActionResult Create()
        {
            ViewData["IdModel"] = new SelectList(_context.Models, "IdModel", "IdModel");
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii");
            return View();
        }

        // POST: Administreazas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdministreaza,IdServicii,IdModel")] Administreaza administreaza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administreaza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdModel"] = new SelectList(_context.Models, "IdModel", "IdModel", administreaza.IdModel);
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii", administreaza.IdServicii);
            return View(administreaza);
        }

        // GET: Administreazas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Administreazas == null)
            {
                return NotFound();
            }

            var administreaza = await _context.Administreazas.FindAsync(id);
            if (administreaza == null)
            {
                return NotFound();
            }
            ViewData["IdModel"] = new SelectList(_context.Models, "IdModel", "IdModel", administreaza.IdModel);
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii", administreaza.IdServicii);
            return View(administreaza);
        }

        // POST: Administreazas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdministreaza,IdServicii,IdModel")] Administreaza administreaza)
        {
            if (id != administreaza.IdAdministreaza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administreaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministreazaExists(administreaza.IdAdministreaza))
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
            ViewData["IdModel"] = new SelectList(_context.Models, "IdModel", "IdModel", administreaza.IdModel);
            ViewData["IdServicii"] = new SelectList(_context.Serviciis, "IdServicii", "IdServicii", administreaza.IdServicii);
            return View(administreaza);
        }

        // GET: Administreazas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Administreazas == null)
            {
                return NotFound();
            }

            var administreaza = await _context.Administreazas
                .Include(a => a.IdModelNavigation)
                .Include(a => a.IdServiciiNavigation)
                .FirstOrDefaultAsync(m => m.IdAdministreaza == id);
            if (administreaza == null)
            {
                return NotFound();
            }

            return View(administreaza);
        }

        // POST: Administreazas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Administreazas == null)
            {
                return Problem("Entity set 'ProiectContext.Administreazas'  is null.");
            }
            var administreaza = await _context.Administreazas.FindAsync(id);
            if (administreaza != null)
            {
                _context.Administreazas.Remove(administreaza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministreazaExists(int id)
        {
          return (_context.Administreazas?.Any(e => e.IdAdministreaza == id)).GetValueOrDefault();
        }
    }
}
