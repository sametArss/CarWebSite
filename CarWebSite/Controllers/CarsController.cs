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
    private readonly IExpertisesService _expertisesService;
    private readonly IPieceStatusService _pieceStatusService;

    public CarsController(ICarsService carsService, IBrandService brandService, IModelsService modelsService, ICarImageService carImageService, IExpertisesService expertisesService, IPieceStatusService pieceStatusService)
    {
        _carsService = carsService;
        _brandService = brandService;
        _modelsService = modelsService;
        _carImageService = carImageService;
        _expertisesService = expertisesService;
        _pieceStatusService = pieceStatusService;
    }

    public IActionResult Index()
    {
        var values = _carsService.GetAllCars();
        return View(values);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _carsService.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Detail(int id)
    {
        var car = _carsService.GetByIdCars(id);
        if (car == null)
            return NotFound();

        // Brand ve Model adını çek
        var brand = _brandService.GetAllBrands().FirstOrDefault(b => b.BrandId == car.BrandId);
        var model = _modelsService.GetAllModels().FirstOrDefault(m => m.ModelId == car.ModelId);
        ViewBag.BrandName = brand?.BrandName;
        ViewBag.ModelName = model?.ModelName;

        var expertise = _expertisesService.GetByIdExpertise(id);
        ViewBag.Expertise = expertise;
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
        car.CarId = 0;
        car.CreatedAt = DateTime.UtcNow; 
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

        ViewBag.Brands = _brandService.GetAllBrands();
        return View(car);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var car = _carsService.GetByIdCars(id);
        if (car == null)
            return NotFound();
        ViewBag.Brands = _brandService.GetAllBrands();
        // Model için markaya göre modelleri getir
        ViewBag.Models = _modelsService.GetModelBrandId(car.BrandId);
        return View(car);
    }

    [HttpPost]
    public IActionResult Edit(Cars car)
    {
        ModelState.Remove("CarImages");
        if (ModelState.IsValid)
        {
            _carsService.Update(car);
            return RedirectToAction("Index");
        }
        ViewBag.Brands = _brandService.GetAllBrands();
        ViewBag.Models = _modelsService.GetModelBrandId(car.BrandId);
        return View(car);
    }

   
}
