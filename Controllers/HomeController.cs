using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FranchiseManagement.Models;
using FranchiseManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace FranchiseManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Background = "";
            IEnumerable<FoodTruck> trucks = _context.FoodTrucks
                                                    .Include(t => t.Location)
                                                    .ToList();
            return View(trucks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Menu(int id)
        {
            FoodTruck foodTruck = _context.FoodTrucks
                                            .Where(t => t.FoodTruckID == id)
                                            .Include(t => t.Menu)
                                            .Include(t => t.Location)
                                            .FirstOrDefault();
            foodTruck.Menu.Clear();
            if (foodTruck.Menu.Count == 0)
            {
                foodTruck.Menu.Add(_context.FoodItems.Where(f => f.FoodItemID == foodTruck.FoodTruckID + 0).FirstOrDefault());
                foodTruck.Menu.Add(_context.FoodItems.Where(f => f.FoodItemID == foodTruck.FoodTruckID + 2).FirstOrDefault());
                foodTruck.Menu.Add(_context.FoodItems.Where(f => f.FoodItemID == foodTruck.FoodTruckID + 3).FirstOrDefault());
                _context.SaveChangesAsync();
            }
            return View(foodTruck);
        }
    }
}
