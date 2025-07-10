using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntityLayer.Models;
using System.Collections.Generic;

namespace BusiniessLayer.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public void AddImages(List<CarImage> images)
        {
            foreach (var image in images)
            {
                _carImageDal.Insert(image);
            }
        }
    }
} 