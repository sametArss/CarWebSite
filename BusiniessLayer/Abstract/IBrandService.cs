using EntityLayer.Models;
using System.Collections.Generic;

namespace BusiniessLayer.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAllBrands();
        Brand GetBrandById(int id);
        void AddBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
} 