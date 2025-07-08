using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CarWebSite.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;   
        }

        public IActionResult Index()
        {
            var values = _carsService.GetAllCars();
            return View(values);
        }
    }
}
