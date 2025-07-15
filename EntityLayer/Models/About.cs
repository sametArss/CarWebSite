using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class About
    {
        [Key]
        public int AboutId  { get; set; }
        [Required]
        public string AboutMessage { get; set; }
    }
}
