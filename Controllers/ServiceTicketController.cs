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
    public class ServiceTicketController : Controller
    {
        private readonly WorkshopContext _context;

        public ServiceTicketController(WorkshopContext context)
        {
            _context = context;
        }

        // GET: ServiceTicket
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceTicket.ToListAsync());
        }

        // GET: ServiceTicket/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTicket = await _context.ServiceTicket
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceTicket == null)
            {
                return NotFound();
            }

            return View(serviceTicket);
        }

        // GET: ServiceTicket/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceTicket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CarId,MechanicId,ServiceStatusId,ServiceTypeId,PriceTotal,CaseDescription")] ServiceTicket serviceTicket)
        {
            if (ModelState.IsValid)
            {
                serviceTicket.ID = Guid.NewGuid();
                _context.Add(serviceTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTicket);
        }

        // GET: ServiceTicket/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTicket = await _context.ServiceTicket.FindAsync(id);
            if (serviceTicket == null)
            {
                return NotFound();
            }
            return View(serviceTicket);
        }

        // POST: ServiceTicket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CarId,MechanicId,ServiceStatusId,ServiceTypeId,PriceTotal,CaseDescription")] ServiceTicket serviceTicket)
        {
            if (id != serviceTicket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceTicketExists(serviceTicket.ID))
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
            return View(serviceTicket);
        }

        // GET: ServiceTicket/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTicket = await _context.ServiceTicket
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceTicket == null)
            {
                return NotFound();
            }

            return View(serviceTicket);
        }

        // POST: ServiceTicket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var serviceTicket = await _context.ServiceTicket.FindAsync(id);
            if (serviceTicket != null)
            {
                _context.ServiceTicket.Remove(serviceTicket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceTicketExists(Guid id)
        {
            return _context.ServiceTicket.Any(e => e.ID == id);
        }
    }
}
