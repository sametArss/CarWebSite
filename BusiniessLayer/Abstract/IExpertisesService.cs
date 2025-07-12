using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface IExpertisesService
    {

        void Insert(Expertise e);
        Expertise GetByIdExpertise(int id); 
    }
}
