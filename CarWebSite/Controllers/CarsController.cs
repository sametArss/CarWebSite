using BusiniessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CarsController : Controller
{
    private readonly ICarsService _carsService;
    private readonly IBrandService _brandService;
    private readonly IModelsService _modelsService;
    private readonly ICarImageService _carImageService;

    public CarsController(ICarsService carsService, IBrandService brandService, IModelsService modelsService, ICarImageService carImageService)
    {
        _carsService = carsService;
        _brandService = brandService;
        _modelsService = modelsService;
        _carImageService = carImageService;
    }

    public IActionResult Index()
    {
        var values = _carsService.GetAllCars();
        return View(values);
    }

    public IActionResult Detail(int id)
    {
        var car = _carsService.GetAllCars().FirstOrDefault(x => x.CarId == id);
        if (car == null)
            return NotFound();
        return View(car);
    }

    // Marka listesini JSON olarak döner
    [HttpGet]
    public IActionResult GetBrands()
    {
        var brands = _brandService.GetAllBrands();
        return Json(brands);
    }

    // Seçilen markaya göre modelleri JSON olarak döner
    [HttpGet]
    public IActionResult GetModelsByBrand(int brandId)
    {
        var models = _modelsService.GetModelBrandId(brandId);
        return Json(models);
    }

    // Araba ekleme formu (GET)
    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Brands = _brandService.GetAllBrands();
        return View();
    }

    // Araba ekleme işlemi (POST)
    [HttpPost]
    public IActionResult Add(Cars car, List<IFormFile> carImages)
    {
        car.CarId = 0; // CarId'yi sıfırla, EF Core yeni kayıt olarak algılasın
        car.CreatedAt = DateTime.UtcNow; // CreatedAt'i UTC olarak ayarla
        if (ModelState.IsValid)
        {
            // Arabayı kaydet
            _carsService.AddCar(car);

            // Resimleri kaydet
            if (carImages != null && carImages.Count > 0)
            {
                var carImageList = new List<CarImage>();
                foreach (var image in carImages)
                {
                    if (image.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        if (!Directory.Exists(uploadsFolder))
                            Directory.CreateDirectory(uploadsFolder);
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }
                        carImageList.Add(new CarImage { CarId = car.CarId, ImagePath = "/images/" + uniqueFileName, UploadedAt = DateTime.UtcNow });
                    }
                }
                if (carImageList.Count > 0)
                {
                    _carImageService.AddImages(carImageList);
                }
            }
            return RedirectToAction("Index");
        }
        // ModelState hatalarını alan adıyla birlikte TempData'ya yazdır
        //var errorList = ModelState
        //    .Where(ms => ms.Value.Errors.Count > 0)
        //    .Select(ms => $"<b>{ms.Key}</b>: {string.Join(", ", ms.Value.Errors.Select(e => e.ErrorMessage))}")
        //    .ToList();
        //TempData["FormErrors"] = string.Join("<br>", errorList);
        ViewBag.Brands = _brandService.GetAllBrands();
        return View(car);
    }
}
