using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.EntityFramework
{
    public class EFMessageDal : GenericRepositoriesDal<Message>, IMessageDal
    {
        public EFMessageDal(AppDbContext context) : base(context)
        {
        }
    }
}
