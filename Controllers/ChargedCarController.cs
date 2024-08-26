using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Workshop.Data;
using Workshop.Models;

namespace Workshop.Controllers
{
    public class ChargedCarController : Controller
    {
        private readonly WorkshopContext _context;

        public ChargedCarController(WorkshopContext context)
        {
            _context = context;
        }

        // GET: ChargedCar
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChargedCar.ToListAsync());
        }

        // GET: ChargedCar/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chargedCar = await _context.ChargedCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chargedCar == null)
            {
                return NotFound();
            }

            return View(chargedCar);
        }

        // GET: ChargedCar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChargedCar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LicensePlate,Kwh,dateTime,PriceTotal")] ChargedCar chargedCar)
        {
            if (ModelState.IsValid)
            {
                chargedCar.ID = Guid.NewGuid();
                _context.Add(chargedCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chargedCar);
        }

        // GET: ChargedCar/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chargedCar = await _context.ChargedCar.FindAsync(id);
            if (chargedCar == null)
            {
                return NotFound();
            }
            return View(chargedCar);
        }

        // POST: ChargedCar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,LicensePlate,Kwh,dateTime,PriceTotal")] ChargedCar chargedCar)
        {
            if (id != chargedCar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chargedCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargedCarExists(chargedCar.ID))
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
            return View(chargedCar);
        }

        // GET: ChargedCar/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chargedCar = await _context.ChargedCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chargedCar == null)
            {
                return NotFound();
            }

            return View(chargedCar);
        }

        // POST: ChargedCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var chargedCar = await _context.ChargedCar.FindAsync(id);
            if (chargedCar != null)
            {
                _context.ChargedCar.Remove(chargedCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChargedCarExists(Guid id)
        {
            return _context.ChargedCar.Any(e => e.ID == id);
        }
    }
}
