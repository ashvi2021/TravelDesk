using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Controllers
{
    public class ApplicationRequestHistoriesController : Controller
    {
        private readonly TravelDeskDbContext _context;

        public ApplicationRequestHistoriesController(TravelDeskDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationRequestHistories
        public async Task<IActionResult> Index()
        {
            var travelDeskDbContext = _context.applicationrequestsHistory.Include(a => a.ApplicationRequest);
            return View(await travelDeskDbContext.ToListAsync());
        }

        // GET: ApplicationRequestHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.applicationrequestsHistory == null)
            {
                return NotFound();
            }

            var applicationRequestHistory = await _context.applicationrequestsHistory
                .Include(a => a.ApplicationRequest)
                .FirstOrDefaultAsync(m => m.ApplicationRequestHistoryId == id);
            if (applicationRequestHistory == null)
            {
                return NotFound();
            }

            return View(applicationRequestHistory);
        }

        // GET: ApplicationRequestHistories/Create
        public IActionResult Create()
        {
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId");
            return View();
        }

        // POST: ApplicationRequestHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationRequestHistoryId,RequestStatus,ApplicationRequestId")] ApplicationRequestHistory applicationRequestHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationRequestHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId", applicationRequestHistory.ApplicationRequestId);
            return View(applicationRequestHistory);
        }

        // GET: ApplicationRequestHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.applicationrequestsHistory == null)
            {
                return NotFound();
            }

            var applicationRequestHistory = await _context.applicationrequestsHistory.FindAsync(id);
            if (applicationRequestHistory == null)
            {
                return NotFound();
            }
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId", applicationRequestHistory.ApplicationRequestId);
            return View(applicationRequestHistory);
        }

        // POST: ApplicationRequestHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationRequestHistoryId,RequestStatus,ApplicationRequestId")] ApplicationRequestHistory applicationRequestHistory)
        {
            if (id != applicationRequestHistory.ApplicationRequestHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationRequestHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationRequestHistoryExists(applicationRequestHistory.ApplicationRequestHistoryId))
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
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId", applicationRequestHistory.ApplicationRequestId);
            return View(applicationRequestHistory);
        }

        // GET: ApplicationRequestHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.applicationrequestsHistory == null)
            {
                return NotFound();
            }

            var applicationRequestHistory = await _context.applicationrequestsHistory
                .Include(a => a.ApplicationRequest)
                .FirstOrDefaultAsync(m => m.ApplicationRequestHistoryId == id);
            if (applicationRequestHistory == null)
            {
                return NotFound();
            }

            return View(applicationRequestHistory);
        }

        // POST: ApplicationRequestHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.applicationrequestsHistory == null)
            {
                return Problem("Entity set 'TravelDeskDbContext.applicationrequestsHistory'  is null.");
            }
            var applicationRequestHistory = await _context.applicationrequestsHistory.FindAsync(id);
            if (applicationRequestHistory != null)
            {
                _context.applicationrequestsHistory.Remove(applicationRequestHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationRequestHistoryExists(int id)
        {
          return (_context.applicationrequestsHistory?.Any(e => e.ApplicationRequestHistoryId == id)).GetValueOrDefault();
        }
    }
}
