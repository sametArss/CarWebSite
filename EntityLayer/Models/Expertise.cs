using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class Expertise
    {
        [Key]
        public int ExpertiseId { get; set; }

        public int CarId { get; set; }
        [ValidateNever]
        public virtual Cars Car { get; set; }

        public int KaputStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus KaputStatus { get; set; }

        public int TavanStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus TavanStatus { get; set; }

        public int BagajStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus BagajStatus { get; set; }

        public int SolOnKapıStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SolOnKapıStatus { get; set; }

        public int SagOnKapıStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SagOnKapıStatus { get; set; }

        public int SolArkaKapıStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SolArkaKapıStatus { get; set; }

        public int SagArkaKapıStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SagArkaKapıStatus { get; set; }

        public int SolOnCamurlukStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SolOnCamurlukStatus { get; set; }

        public int SagOnCamurlukStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SagOnCamurlukStatus { get; set; }

        public int SolArkaCamurlukStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SolArkaCamurlukStatus { get; set; }

        public int SagArkaCamurlukStatusId { get; set; }
        [ValidateNever]
        public virtual PieceStatus SagArkaCamurlukStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
