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
            var expertiseValue = _expertisesService.GetByIdExpertise(expertise.CarId);

            if (ModelState.IsValid && expertiseValue == null)
            {
                _expertisesService.Insert(expertise);
                TempData["Message"] = "Ekspertiz başarıyla eklendi!";
                return RedirectToAction("Index", "Cars");
            }
            else if (ModelState.IsValid && expertiseValue != null)
            {
                expertiseValue.KaputStatusId = expertise.KaputStatusId;
                expertiseValue.TavanStatusId = expertise.TavanStatusId;
                expertiseValue.BagajStatusId = expertise.BagajStatusId;
                expertiseValue.SolOnKapıStatusId = expertise.SolOnKapıStatusId;
                expertiseValue.SagOnKapıStatusId = expertise.SagOnKapıStatusId;
                expertiseValue.SolArkaKapıStatusId = expertise.SolArkaKapıStatusId;
                expertiseValue.SagArkaKapıStatusId = expertise.SagArkaKapıStatusId;
                expertiseValue.SolOnCamurlukStatusId = expertise.SolOnCamurlukStatusId;
                expertiseValue.SagOnCamurlukStatusId = expertise.SagOnCamurlukStatusId;
                expertiseValue.SolArkaCamurlukStatusId = expertise.SolArkaCamurlukStatusId;
                expertiseValue.SagArkaCamurlukStatusId = expertise.SagArkaCamurlukStatusId;
                expertiseValue.CreatedAt = expertise.CreatedAt;

                _expertisesService.Update(expertiseValue);
                TempData["Message"] = "Ekspertiz başarıyla güncellendi!";
                return RedirectToAction("Index", "Cars");
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