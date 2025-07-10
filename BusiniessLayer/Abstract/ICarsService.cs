using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface ICarsService
    {
        List<Cars> GetAllCars();
        void AddCar(Cars car);
    }
}
