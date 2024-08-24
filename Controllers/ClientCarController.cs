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
    public class ClientCarController : Controller
    {
        private readonly WorkshopContext _context;

        public ClientCarController(WorkshopContext context)
        {
            _context = context;
        }

        // GET: ClientCar
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientCar.ToListAsync());
        }

        // GET: ClientCar/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCar = await _context.ClientCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientCar == null)
            {
                return NotFound();
            }

            return View(clientCar);
        }

        // GET: ClientCar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientCar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientId,CarId")] ClientCar clientCar)
        {
            if (ModelState.IsValid)
            {
                // Validation of CarId. If it already exists in the table, user will not go through
                var existingCarId = await _context.ClientCar.FirstOrDefaultAsync(c => c.CarId == clientCar.CarId);
                if (existingCarId != null)
                {
                    ModelState.AddModelError("CarId", "A car with this id already exists.");
                    return View(clientCar);
                }
                clientCar.ID = Guid.NewGuid();
                _context.Add(clientCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientCar);
        }

        // GET: ClientCar/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCar = await _context.ClientCar.FindAsync(id);
            if (clientCar == null)
            {
                return NotFound();
            }
            return View(clientCar);
        }

        // POST: ClientCar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,ClientId,CarId")] ClientCar clientCar)
        {
            if (id != clientCar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientCarExists(clientCar.ID))
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
            return View(clientCar);
        }

        // GET: ClientCar/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCar = await _context.ClientCar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientCar == null)
            {
                return NotFound();
            }

            return View(clientCar);
        }

        // POST: ClientCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clientCar = await _context.ClientCar.FindAsync(id);
            if (clientCar != null)
            {
                _context.ClientCar.Remove(clientCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientCarExists(Guid id)
        {
            return _context.ClientCar.Any(e => e.ID == id);
        }
    }
}
