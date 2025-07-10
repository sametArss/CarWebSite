using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Reflection;

namespace EntityLayer.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [ValidateNever]
        public virtual Brand Brand { get; set; }

        [Required]
        public int ModelId { get; set; }

        [ValidateNever]
        public virtual Models Models { get; set; }

        [Required]
        public int KiloMetre { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool CarStatus { get; set; }

        [Required]
        public string CarDescription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Her araç bir ekspertize sahiptir (1-1 ilişki)
        public virtual Expertise? Expertise { get; set; }

        // Bir aracın birden fazla fotoğrafı olabilir (1-Çok ilişki)
        public virtual ICollection<CarImage> CarImages { get; set; }
    }
}
