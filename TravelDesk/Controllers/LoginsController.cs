using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Controllers
{
    public class LoginsController : Controller
    {
        private readonly TravelDeskDbContext _context;

        public LoginsController(TravelDeskDbContext context)
        {
            _context = context;
        }

        

       // GET: Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //_context.Add(login);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));

public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.login.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password); 
                if (user != null)
                { // User found, redirect to the desired page
                  return RedirectToAction("Index", "Users"); 
                }
                ModelState.AddModelError(string.Empty, "Invalid username or password"); }
            return View(login);
        }
    }










                   
    }

