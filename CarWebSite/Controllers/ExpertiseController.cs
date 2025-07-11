using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAcsessLayer.Concrete.Context;
using EntityLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebSite.Controllers
{
    public class ExpertiseController : Controller
    {
        private readonly AppDbContext _context;
        public ExpertiseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Expertise/Create/{carId}
        public async Task<IActionResult> Create(int carId)
        {
            var pieceStatuses = await _context.PieceStatuses.ToListAsync();
            ViewBag.PieceStatuses = pieceStatuses;
            ViewBag.CarId = carId;
            return View();
        }

        // POST: /Expertise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expertise expertise)
        {
            if (ModelState.IsValid)
            {
                _context.Expertises.Add(expertise);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Cars"); // veya başka bir uygun sayfa
            }
            ViewBag.PieceStatuses = await _context.PieceStatuses.ToListAsync();
            ViewBag.CarId = expertise.CarId;
            return View(expertise);
        }

        // GET: /Expertise/Index
        public async Task<IActionResult> Index()
        {
            var expertises = await _context.Expertises.Include(e => e.Car).ToListAsync();
            return View(expertises);
        }
    }
} 