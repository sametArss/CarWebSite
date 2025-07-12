using BusiniessLayer.Abstract;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class ExpertiseManager:IExpertisesService
    {
        private readonly IExpertiseDal _expertiseDal;
        public ExpertiseManager(IExpertiseDal expertiseDal)
        {
            _expertiseDal = expertiseDal;
        }

        public Expertise GetByIdExpertise(int id)
        {
            return _expertiseDal.GetByFilter(x=>x.CarId==id);
        }

        public void Insert(Expertise e)
        {
            _expertiseDal.Insert(e);
        }
    }
}
