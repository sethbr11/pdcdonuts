using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using donuts.Models;
using System.Linq;


namespace donuts.Controllers
{
    public class HomeController : Controller
    {
        private DonutDbContext _context;

        public HomeController(DonutDbContext ddc)
        {
            _context = ddc;
        }
        public IActionResult Index()
        {
            var donuts = _context.Donuts.ToList();

            return View(donuts);
        }
    }
}
