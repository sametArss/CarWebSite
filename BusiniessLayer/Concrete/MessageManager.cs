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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal )
        {
            _messageDal = messageDal;
        }

        public void Delete(int id)
        {
           var deleteMessage = _messageDal.GetById(id);
            _messageDal.Delete(deleteMessage);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetAllFilter()
        {
            return _messageDal.GetAllFilter(x=>x.IsRead==false);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void Insert(Message message)
        {
           _messageDal.Insert(message);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
