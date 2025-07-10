using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class CarImage
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; } // e.g., "uploads/cars/5/photo1.jpg"
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual Cars Car { get; set; }
    }
} 