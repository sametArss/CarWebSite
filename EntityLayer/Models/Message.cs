using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string NameLName { get; set; }
        [Required]
        public  string Mail { get; set; }
        [Required]
        public string Messagess { get; set; }

        public bool IsRead { get; set; } = false;
        public DateTime MessageCreateDate { get; set; } = DateTime.UtcNow;
    }
}
