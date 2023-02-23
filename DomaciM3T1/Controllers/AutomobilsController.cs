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
    public class AutomobilsController : Controller
    {
        private readonly AppDbContext _context;

        public AutomobilsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Automobils
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Automobils.Include(a => a.Proizvodjac).Include(a => a.Salon);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Automobils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobils
                .Include(a => a.Proizvodjac)
                .Include(a => a.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Automobils/Create
        public IActionResult Create()
        {
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjacs, "Id", "Naziv");
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv");
            return View();
        }

        // POST: Automobils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,GodinaProizvodnje,Kubikaza,Boja,ProizvodjacId,SalonId")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                var proizvodjac = await _context.Proizvodjacs.FindAsync(automobil.ProizvodjacId);
                var salon = await _context.Salon.FindAsync(automobil.SalonId);
                if (salon != null)
                {
                    var proizvodjaci = await _context.Proizvodjacs
                        .Where(p => p.SalonId == salon.Id)
                        .ToListAsync();
                    salon.Proizvodjacs = proizvodjaci;
                }

                if (proizvodjac != null && salon != null && salon.Proizvodjacs.Contains(proizvodjac))
                {
                    _context.Add(automobil);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("SalonId", "Proizvodjac nema ugovor sa odabranim salonom.");
                }
            }

            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjacs, "Id", "Naziv", automobil.ProizvodjacId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv", automobil.SalonId);
            return View(automobil);
        }

        // GET: Automobils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobils.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjacs, "Id", "Naziv", automobil.ProizvodjacId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv", automobil.SalonId);
            return View(automobil);
        }

        // POST: Automobils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,GodinaProizvodnje,Kubikaza,Boja,ProizvodjacId,SalonId")] Automobil automobil)
        {
            if (id != automobil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.Id))
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
            ViewData["ProizvodjacId"] = new SelectList(_context.Proizvodjacs, "Id", "Naziv", automobil.ProizvodjacId);
            ViewData["SalonId"] = new SelectList(_context.Salon, "Id", "Naziv", automobil.SalonId);
            return View(automobil);
        }

        // GET: Automobils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobils
                .Include(a => a.Proizvodjac)
                .Include(a => a.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // POST: Automobils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automobil = await _context.Automobils.FindAsync(id);
            _context.Automobils.Remove(automobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(int id)
        {
            return _context.Automobils.Any(e => e.Id == id);
        }
    }
}
