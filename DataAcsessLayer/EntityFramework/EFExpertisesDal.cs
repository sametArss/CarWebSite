using BusiniessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class EFExpertisesDal : GenericRepositoriesDal<Expertise>, IExpertiseDal
    {
        public EFExpertisesDal(AppDbContext context) : base(context)
        {
        }
    }
}
