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
    public class ServiceStatusController : Controller
    {
        private readonly WorkshopContext _context;

        public ServiceStatusController(WorkshopContext context)
        {
            _context = context;
        }

        // GET: ServiceStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceStatus.ToListAsync());
        }

        // GET: ServiceStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceStatus = await _context.ServiceStatus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceStatus == null)
            {
                return NotFound();
            }

            return View(serviceStatus);
        }

        // GET: ServiceStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ServiceStatusName")] ServiceStatus serviceStatus)
        {
            if (ModelState.IsValid)
            {
                serviceStatus.ID = Guid.NewGuid();
                _context.Add(serviceStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceStatus);
        }

        // GET: ServiceStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceStatus = await _context.ServiceStatus.FindAsync(id);
            if (serviceStatus == null)
            {
                return NotFound();
            }
            return View(serviceStatus);
        }

        // POST: ServiceStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,ServiceStatusName")] ServiceStatus serviceStatus)
        {
            if (id != serviceStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceStatusExists(serviceStatus.ID))
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
            return View(serviceStatus);
        }

        // GET: ServiceStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceStatus = await _context.ServiceStatus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceStatus == null)
            {
                return NotFound();
            }

            return View(serviceStatus);
        }

        // POST: ServiceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var serviceStatus = await _context.ServiceStatus.FindAsync(id);
            if (serviceStatus != null)
            {
                _context.ServiceStatus.Remove(serviceStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceStatusExists(Guid id)
        {
            return _context.ServiceStatus.Any(e => e.ID == id);
        }
    }
}
