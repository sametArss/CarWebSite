using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Abstract
{
    public interface IAboutDal:IRepositoriesDal<About>
    {
        About GetAbout();
    }
}
