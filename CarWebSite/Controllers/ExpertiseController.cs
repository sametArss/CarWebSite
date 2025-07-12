using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAcsessLayer.Concrete.Context;
using EntityLayer.Models;
using System.Linq;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;

namespace CarWebSite.Controllers
{
    public class ExpertiseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPieceStatusService _pieceStatusService;
        private readonly IExpertisesService _expertisesService;

        public ExpertiseController(AppDbContext context , IPieceStatusService pieceStatusService, IExpertisesService expertisesService)
        {
            _context = context;
            _pieceStatusService = pieceStatusService;
            _expertisesService = expertisesService;
        }

        // GET: /Expertise/Create/{carId}
        [HttpGet]
        public async Task<IActionResult> Create(int carId)
        {
            var pieceStatuses =_pieceStatusService.GetAll();
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
                //_context.Expertises.Add(expertise);
                //await _context.SaveChangesAsync();
                _expertisesService.Insert(expertise);
                return RedirectToAction("Index", "Cars"); // veya başka bir uygun sayfa
            }
            ViewBag.PieceStatuses = _pieceStatusService.GetAll();
            ViewBag.CarId = expertise.CarId;
            return View(expertise);
        }

        // GET: /Expertise/Index
        public async Task<IActionResult> Index(int id)
        {
            var value = _expertisesService.GetByIdExpertise(id);
            return View(value);
        }
    }
} 