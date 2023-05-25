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
    public class HistoryDetailsController : Controller
    {
        private readonly TravelDeskDbContext _context;

        public HistoryDetailsController(TravelDeskDbContext context)
        {
            _context = context;
        }

        // GET: HistoryDetails
        public async Task<IActionResult> Index()
        {
            var travelDeskDbContext = _context.historyDetails.Include(h => h.ApplicationRequest);
            return View(await travelDeskDbContext.ToListAsync());
        }

        // GET: HistoryDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.historyDetails == null)
            {
                return NotFound();
            }

            var historyDetails = await _context.historyDetails
                .Include(h => h.ApplicationRequest)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (historyDetails == null)
            {
                return NotFound();
            }

            return View(historyDetails);
        }

        // GET: HistoryDetails/Create
        public IActionResult Create()
        {
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId");
            return View();
        }

        // POST: HistoryDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,ApplicationRequestId")] HistoryDetails historyDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historyDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId", historyDetails.ApplicationRequestId);
            return View(historyDetails);
        }

        // GET: HistoryDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.historyDetails == null)
            {
                return NotFound();
            }

            var historyDetails = await _context.historyDetails.FindAsync(id);
            if (historyDetails == null)
            {
                return NotFound();
            }
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId", historyDetails.ApplicationRequestId);
            return View(historyDetails);
        }

        // POST: HistoryDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoryId,ApplicationRequestId")] HistoryDetails historyDetails)
        {
            if (id != historyDetails.HistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historyDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryDetailsExists(historyDetails.HistoryId))
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
            ViewData["ApplicationRequestId"] = new SelectList(_context.applicationrequests, "RequestId", "RequestId", historyDetails.ApplicationRequestId);
            return View(historyDetails);
        }

        // GET: HistoryDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.historyDetails == null)
            {
                return NotFound();
            }

            var historyDetails = await _context.historyDetails
                .Include(h => h.ApplicationRequest)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (historyDetails == null)
            {
                return NotFound();
            }

            return View(historyDetails);
        }

        // POST: HistoryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.historyDetails == null)
            {
                return Problem("Entity set 'TravelDeskDbContext.historyDetails'  is null.");
            }
            var historyDetails = await _context.historyDetails.FindAsync(id);
            if (historyDetails != null)
            {
                _context.historyDetails.Remove(historyDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryDetailsExists(int id)
        {
          return (_context.historyDetails?.Any(e => e.HistoryId == id)).GetValueOrDefault();
        }
    }
}
