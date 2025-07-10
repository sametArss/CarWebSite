using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntityLayer.Models;
using System.Collections.Generic;

namespace BusiniessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void AddBrand(Brand brand)
        {
            _brandDal.Insert(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAllBrands()
        {
            return _brandDal.GetAll();
        }

        public Brand GetBrandById(int id)
        {
            return _brandDal.GetById(id);
        }

        public void UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
} 