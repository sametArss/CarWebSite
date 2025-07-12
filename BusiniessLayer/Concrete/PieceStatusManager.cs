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
    public class PieceStatusManager : IPieceStatusService
    {
        private readonly IPieceStatusDal _pieceStatusDal;

        public PieceStatusManager(IPieceStatusDal pieceStatusDal)
        {
                _pieceStatusDal = pieceStatusDal;
        }

        public List<PieceStatus> GetAll()
        {
           return _pieceStatusDal.GetAll();
        }
    }
}
