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
    public class ApplicationRequestsController : Controller
    {
        private readonly TravelDeskDbContext _context;

        public ApplicationRequestsController(TravelDeskDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationRequests
        public async Task<IActionResult> Index()
        {
            var travelDeskDbContext = _context.applicationrequests.Include(a => a.Comment).Include(a => a.Department).Include(a => a.Document).Include(a => a.Hotel).Include(a => a.User);
            return View(await travelDeskDbContext.ToListAsync());
        }

        // GET: ApplicationRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.applicationrequests == null)
            {
                return NotFound();
            }

            var applicationRequest = await _context.applicationrequests
                .Include(a => a.Comment)
                .Include(a => a.Department)
                .Include(a => a.Document)
                .Include(a => a.Hotel)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (applicationRequest == null)
            {
                return NotFound();
            }

            return View(applicationRequest);
        }

        // GET: ApplicationRequests/Create
        public IActionResult Create()
        {
            ViewData["CommentId"] = new SelectList(_context.comments, "CommentId", "CommentId");
            ViewData["DepartmentId"] = new SelectList(_context.department, "DepartmentId", "DepartmentId");
            ViewData["DocumentId"] = new SelectList(_context.documents, "DocumentId", "DocumentId");
            ViewData["HotelId"] = new SelectList(_context.hotel, "HotelId", "HotelId");
            ViewData["UserId"] = new SelectList(_context.users, "UserId", "UserId");
            return View();
        }

        // POST: ApplicationRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,UserId,Location,DepartmentId,DocumentId,ReasonForTravelling,DepartureCity,DestinationCity,DepartureDate,DurationOfTravel,HotelRequired,HotelId,MealNeeded,TravelModel,CommentId")] ApplicationRequest applicationRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentId"] = new SelectList(_context.comments, "CommentId", "CommentId", applicationRequest.CommentId);
            ViewData["DepartmentId"] = new SelectList(_context.department, "DepartmentId", "DepartmentId", applicationRequest.DepartmentId);
            ViewData["DocumentId"] = new SelectList(_context.documents, "DocumentId", "DocumentId", applicationRequest.DocumentId);
            ViewData["HotelId"] = new SelectList(_context.hotel, "HotelId", "HotelId", applicationRequest.HotelId);
            ViewData["UserId"] = new SelectList(_context.users, "UserId", "UserId", applicationRequest.UserId);
            return View(applicationRequest);
        }

        // GET: ApplicationRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.applicationrequests == null)
            {
                return NotFound();
            }

            var applicationRequest = await _context.applicationrequests.FindAsync(id);
            if (applicationRequest == null)
            {
                return NotFound();
            }
            ViewData["CommentId"] = new SelectList(_context.comments, "CommentId", "CommentId", applicationRequest.CommentId);
            ViewData["DepartmentId"] = new SelectList(_context.department, "DepartmentId", "DepartmentId", applicationRequest.DepartmentId);
            ViewData["DocumentId"] = new SelectList(_context.documents, "DocumentId", "DocumentId", applicationRequest.DocumentId);
            ViewData["HotelId"] = new SelectList(_context.hotel, "HotelId", "HotelId", applicationRequest.HotelId);
            ViewData["UserId"] = new SelectList(_context.users, "UserId", "UserId", applicationRequest.UserId);
            return View(applicationRequest);
        }

        // POST: ApplicationRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,UserId,Location,DepartmentId,DocumentId,ReasonForTravelling,DepartureCity,DestinationCity,DepartureDate,DurationOfTravel,HotelRequired,HotelId,MealNeeded,TravelModel,CommentId")] ApplicationRequest applicationRequest)
        {
            if (id != applicationRequest.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationRequestExists(applicationRequest.RequestId))
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
            ViewData["CommentId"] = new SelectList(_context.comments, "CommentId", "CommentId", applicationRequest.CommentId);
            ViewData["DepartmentId"] = new SelectList(_context.department, "DepartmentId", "DepartmentId", applicationRequest.DepartmentId);
            ViewData["DocumentId"] = new SelectList(_context.documents, "DocumentId", "DocumentId", applicationRequest.DocumentId);
            ViewData["HotelId"] = new SelectList(_context.hotel, "HotelId", "HotelId", applicationRequest.HotelId);
            ViewData["UserId"] = new SelectList(_context.users, "UserId", "UserId", applicationRequest.UserId);
            return View(applicationRequest);
        }

        // GET: ApplicationRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.applicationrequests == null)
            {
                return NotFound();
            }

            var applicationRequest = await _context.applicationrequests
                .Include(a => a.Comment)
                .Include(a => a.Department)
                .Include(a => a.Document)
                .Include(a => a.Hotel)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (applicationRequest == null)
            {
                return NotFound();
            }

            return View(applicationRequest);
        }

        // POST: ApplicationRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.applicationrequests == null)
            {
                return Problem("Entity set 'TravelDeskDbContext.applicationrequests'  is null.");
            }
            var applicationRequest = await _context.applicationrequests.FindAsync(id);
            if (applicationRequest != null)
            {
                _context.applicationrequests.Remove(applicationRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationRequestExists(int id)
        {
          return (_context.applicationrequests?.Any(e => e.RequestId == id)).GetValueOrDefault();
        }
    }
}
