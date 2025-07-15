using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAcsessLayer.EntityFramework
{
    public class EFCarsDal : GenericRepositoriesDal<Cars>, ICarsDal
    {
        public EFCarsDal(AppDbContext context) : base(context)
        {

        }

        public Cars GetByIdCars(int id)
        {
            return _context.Cars
        .Include(c => c.CarImages)
        .FirstOrDefault(c => c.CarId == id);
        }
    }
}
