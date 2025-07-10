using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Models;

namespace DataAcsessLayer.EntityFramework
{
    public class EFCarImageDal : GenericRepositoriesDal<CarImage>, ICarImageDal
    {
        public EFCarImageDal(AppDbContext context) : base(context)
        {
        }
    }
} 