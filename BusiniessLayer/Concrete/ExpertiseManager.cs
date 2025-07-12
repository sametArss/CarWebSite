using BusiniessLayer.Abstract;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAcsessLayer.Concrete.Context;
using System.Security.Cryptography.X509Certificates;

namespace BusiniessLayer.Concrete
{
    public class ExpertiseManager : IExpertisesService
    {
        private readonly IExpertiseDal _expertiseDal;
        private readonly AppDbContext _context;
        public ExpertiseManager(IExpertiseDal expertiseDal, AppDbContext context)
        {
            _expertiseDal = expertiseDal;
            _context = context;
        }

     
        public Expertise GetByIdExpertise(int carId)
        {
            return _expertiseDal.GetByFilter(
    x => x.CarId == carId,
    x => x.KaputStatus,
    x => x.TavanStatus,
    x => x.BagajStatus,
    x => x.SolOnKapıStatus,
    x => x.SagOnKapıStatus,
    x => x.SolArkaKapıStatus,
    x => x.SagArkaKapıStatus,
    x => x.SolOnCamurlukStatus,
    x => x.SagOnCamurlukStatus,
    x => x.SolArkaCamurlukStatus,
    x => x.SagArkaCamurlukStatus
);
        }

        public void Insert(Expertise e)
        {
            _expertiseDal.Insert(e);
        }
    }
}
