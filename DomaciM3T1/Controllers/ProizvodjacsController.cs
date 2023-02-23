using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomaciM3T1.Models;

namespace DomaciM3T1.Controllers
{
    public class ProizvodjacsController : Controller
    {
        private readonly AppDbContext _context;

        public ProizvodjacsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Proizvodjacs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Proizvodjacs.Include(p => p.Salon);
        
            return View(await appDbContext.ToListAsync());
        }

        // GET: Proizvodjacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjacs
                .Include(p => p.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            proizvodjac = _context.Proizvodjacs.Include(p => p.Automobils).FirstOrDefault(p => p.Id == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // GET: Proizvodjacs/Create
        public IActionResult Create()
        {
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv");
            return View();
        }

        // POST: Proizvodjacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Drzava,Grad,SalonId")] Proizvodjac proizvodjac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvodjac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv", proizvodjac.SalonId);
            return View(proizvodjac);
        }

        // GET: Proizvodjacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjacs.FindAsync(id);
            if (proizvodjac == null)
            {
                return NotFound();
            }
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv", proizvodjac.SalonId);
            return View(proizvodjac);
        }

        // POST: Proizvodjacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Drzava,Grad,SalonId")] Proizvodjac proizvodjac)
        {
            if (id != proizvodjac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvodjac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodjacExists(proizvodjac.Id))
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
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv", proizvodjac.SalonId);
            return View(proizvodjac);
        }

        // GET: Proizvodjacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvodjac = await _context.Proizvodjacs
                .Include(p => p.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proizvodjac == null)
            {
                return NotFound();
            }

            return View(proizvodjac);
        }

        // POST: Proizvodjacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvodjac = await _context.Proizvodjacs.FindAsync(id);
            _context.Proizvodjacs.Remove(proizvodjac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodjacExists(int id)
        {
            return _context.Proizvodjacs.Any(e => e.Id == id);
        }
    }
}
