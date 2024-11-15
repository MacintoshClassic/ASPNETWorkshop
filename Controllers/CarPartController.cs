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
    public class CarPartController : Controller
    {
        private readonly WorkshopContext _context;

        public CarPartController(WorkshopContext context)
        {
            _context = context;
        }

        // GET: CarPart
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarPart.ToListAsync());
        }

        // GET: CarPart/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPart = await _context.CarPart
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carPart == null)
            {
                return NotFound();
            }

            return View(carPart);
        }

        // GET: CarPart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarPart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CarPartName,CarId,QuantityAvailable,PricePerUnit,OrderStatusId")] CarPart carPart)
        {
            if (ModelState.IsValid)
            {
                carPart.ID = Guid.NewGuid();
                _context.Add(carPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carPart);
        }

        // GET: CarPart/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPart = await _context.CarPart.FindAsync(id);
            if (carPart == null)
            {
                return NotFound();
            }
            return View(carPart);
        }

        // POST: CarPart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CarPartName,CarId,QuantityAvailable,PricePerUnit,OrderStatusId")] CarPart carPart)
        {
            if (id != carPart.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPartExists(carPart.ID))
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
            return View(carPart);
        }

        // GET: CarPart/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPart = await _context.CarPart
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carPart == null)
            {
                return NotFound();
            }

            return View(carPart);
        }

        // POST: CarPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carPart = await _context.CarPart.FindAsync(id);
            if (carPart != null)
            {
                _context.CarPart.Remove(carPart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPartExists(Guid id)
        {
            return _context.CarPart.Any(e => e.ID == id);
        }
    }
}
