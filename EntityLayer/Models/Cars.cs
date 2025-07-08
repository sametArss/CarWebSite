using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EntityLayer.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int ModelId { get; set; }
        public virtual Models Models { get; set; }

        public int KiloMetre { get; set; }

        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool CarStatus { get; set; }

        public string CarDescription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Her araç bir ekspertize sahiptir (1-1 ilişki)
        public virtual Expertise Expertise { get; set; }
    }
}
