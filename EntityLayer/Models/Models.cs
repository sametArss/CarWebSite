using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Models
    {
        [Key]
        public int ModelId { get; set; }
        public required string ModelName { get; set; }
        public int  BrandId { get; set; }
        public bool ModelStatus { get; set; }

        public ICollection<Cars> Cars { get; set; }
    }
}
