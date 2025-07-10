using EntityLayer.Models;
using System.Collections.Generic;

namespace BusiniessLayer.Abstract
{
    public interface ICarImageService
    {
        void AddImages(List<CarImage> images);
        // Gerekirse diğer metotlar: Get, Delete, vs.
    }
} 