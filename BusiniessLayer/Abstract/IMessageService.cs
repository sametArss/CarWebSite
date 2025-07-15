using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface IMessageService
    {
        void Insert(Message message);
        void Delete(int id);
        List<Message> GetAll();
        List<Message> GetAllFilter();
        Message GetById(int id);
        void Update (Message message);
    }
}
