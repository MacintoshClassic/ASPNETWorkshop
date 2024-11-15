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
    public class CalculatedRepairCostController : Controller
    {
        private readonly WorkshopContext _context;

        public CalculatedRepairCostController(WorkshopContext context)
        {
            _context = context;
        }

        // GET: CalculatedRepairCost
        public async Task<IActionResult> Index()
        {
            return View(await _context.CalculatedRepairCost.ToListAsync());
        }

        // GET: CalculatedRepairCost/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatedRepairCost = await _context.CalculatedRepairCost
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calculatedRepairCost == null)
            {
                return NotFound();
            }

            return View(calculatedRepairCost);
        }

        // GET: CalculatedRepairCost/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalculatedRepairCost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MechanicId,CarPartId,CarPartQuantity,HoursDedicated,PriceTotal")] CalculatedRepairCost calculatedRepairCost)
        {
            // Fetching PricePerUnit from CarPart table based on CarPartId from the input field
            var carPart = _context.CarPart.SingleOrDefault(cp => cp.ID == calculatedRepairCost.CarPartId);

            // Fetching HourlyRate from Mechanic table based on MechanicId from the input field
            var mechanic = _context.Mechanic.SingleOrDefault(m => m.ID == calculatedRepairCost.MechanicId);

            if (carPart == null)
            {
                ModelState.AddModelError("", "Car part not found");
                return View(calculatedRepairCost);
            }

            if (mechanic == null)
            {
                ModelState.AddModelError("", "mechanic part not found");
                return View(calculatedRepairCost);
            }

            if (ModelState.IsValid)
            {
                // Calculating the total price based on CarPartPrice and CarPartQuantity
                calculatedRepairCost.PriceTotal = carPart.PricePerUnit * calculatedRepairCost.CarPartQuantity + (mechanic.HourlyRate * calculatedRepairCost.HoursDedicated);
                calculatedRepairCost.ID = Guid.NewGuid();
                _context.Add(calculatedRepairCost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculatedRepairCost);
        }

        // GET: CalculatedRepairCost/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatedRepairCost = await _context.CalculatedRepairCost.FindAsync(id);
            if (calculatedRepairCost == null)
            {
                return NotFound();
            }
            return View(calculatedRepairCost);
        }

        // POST: CalculatedRepairCost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Mechanicid,CarPartId,CarPartQuantity,HoursDedicated,PriceTotal")] CalculatedRepairCost calculatedRepairCost)
        {
            if (id != calculatedRepairCost.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculatedRepairCost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculatedRepairCostExists(calculatedRepairCost.ID))
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
            return View(calculatedRepairCost);
        }

        // GET: CalculatedRepairCost/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatedRepairCost = await _context.CalculatedRepairCost
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calculatedRepairCost == null)
            {
                return NotFound();
            }

            return View(calculatedRepairCost);
        }

        // POST: CalculatedRepairCost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var calculatedRepairCost = await _context.CalculatedRepairCost.FindAsync(id);
            if (calculatedRepairCost != null)
            {
                _context.CalculatedRepairCost.Remove(calculatedRepairCost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculatedRepairCostExists(Guid id)
        {
            return _context.CalculatedRepairCost.Any(e => e.ID == id);
        }
    }
}

