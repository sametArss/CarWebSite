using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Models;

namespace DataAcsessLayer.EntityFramework
{
    public class EFModelsDal : GenericRepositoriesDal<Models>, IModelsDal
    {
        public EFModelsDal(AppDbContext context) : base(context)
        {
        }
    }
} 