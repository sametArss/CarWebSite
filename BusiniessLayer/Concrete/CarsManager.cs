using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class CarsManager : ICarsService
    {
        private readonly ICarsDal _carsDal;

        public CarsManager(ICarsDal carsDal)
        {
            _carsDal = carsDal;
        }

        public List<Cars> GetAllCars()
        {
            return _carsDal.GetAllFilterInclude(x => x.CarStatus == true,
                x => x.Models,
                x => x.Brand,
                x => x.CarImages);
        }

        public void AddCar(Cars car)
        {
            _carsDal.Insert(car);
        }

        public Cars GetByIdCars(int carId)
        {
            return _carsDal.GetById(carId);
        }
    }
}
