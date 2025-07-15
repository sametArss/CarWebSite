using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class AboutManager:IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About GetAbout()
        {
            return _aboutDal.GetAbout();
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
