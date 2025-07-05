using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public bool BrandStatus { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
