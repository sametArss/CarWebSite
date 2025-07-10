using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Models;

namespace DataAcsessLayer.EntityFramework
{
    public class EFBrandDal : GenericRepositoriesDal<Brand>, IBrandDal
    {
        public EFBrandDal(AppDbContext context) : base(context)
        {
        }
    }
} 