using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FranchiseManagement.Data;
using FranchiseManagement.Models;

namespace FranchiseManagement.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodTrucksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodTrucks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FoodTrucks.Include(f => f.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FoodTrucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks
                .Include(f => f.Location)
                .FirstOrDefaultAsync(m => m.FoodTruckID == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // GET: FoodTrucks/Create
        public IActionResult Create()
        {
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID");
            return View();
        }

        // POST: FoodTrucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodTruckID,Name,LocationID")] FoodTruck foodTruck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodTruck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", foodTruck.LocationID);
            return View(foodTruck);
        }

        // GET: FoodTrucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck == null)
            {
                return NotFound();
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", foodTruck.LocationID);
            return View(foodTruck);
        }

        // POST: FoodTrucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodTruckID,Name,LocationID")] FoodTruck foodTruck)
        {
            if (id != foodTruck.FoodTruckID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodTruck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodTruckExists(foodTruck.FoodTruckID))
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
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", foodTruck.LocationID);
            return View(foodTruck);
        }

        // GET: FoodTrucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks
                .Include(f => f.Location)
                .FirstOrDefaultAsync(m => m.FoodTruckID == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // POST: FoodTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            _context.FoodTrucks.Remove(foodTruck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodTruckExists(int id)
        {
            return _context.FoodTrucks.Any(e => e.FoodTruckID == id);
        }
    }
}
