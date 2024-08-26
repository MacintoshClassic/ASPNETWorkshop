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
    public class RefueledCarController : Controller
    {
        private readonly WorkshopContext _context;

        public RefueledCarController(WorkshopContext context)
        {
            _context = context;
        }

        // GET: RefueledCar
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefueledCar.ToListAsync());
        }

        // GET: RefueledCar/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refueledCar = await _context.RefueledCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (refueledCar == null)
            {
                return NotFound();
            }

            return View(refueledCar);
        }

        // GET: RefueledCar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefueledCar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LicensePlate,Litres,dateTime,PriceTotal")] RefueledCar refueledCar)
        {
            if (ModelState.IsValid)
            {
                refueledCar.ID = Guid.NewGuid();
                _context.Add(refueledCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refueledCar);
        }

        // GET: RefueledCar/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refueledCar = await _context.RefueledCar.FindAsync(id);
            if (refueledCar == null)
            {
                return NotFound();
            }
            return View(refueledCar);
        }

        // POST: RefueledCar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,LicensePlate,Litres,dateTime,PriceTotal")] RefueledCar refueledCar)
        {
            if (id != refueledCar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refueledCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefueledCarExists(refueledCar.ID))
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
            return View(refueledCar);
        }

        // GET: RefueledCar/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refueledCar = await _context.RefueledCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (refueledCar == null)
            {
                return NotFound();
            }

            return View(refueledCar);
        }

        // POST: RefueledCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var refueledCar = await _context.RefueledCar.FindAsync(id);
            if (refueledCar != null)
            {
                _context.RefueledCar.Remove(refueledCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefueledCarExists(Guid id)
        {
            return _context.RefueledCar.Any(e => e.ID == id);
        }
    }
}
