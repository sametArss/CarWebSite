using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class PieceStatus
    {
        [Key]
        public int PieceId { get; set; }
        public string PieceStatusName  { get; set; }
    }
}
