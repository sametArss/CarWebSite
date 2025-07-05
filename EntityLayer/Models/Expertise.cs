using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class Expertise
    {
        [Key]
        public int ExpertiseId { get; set; }

        public int CarId { get; set; }
        public virtual Cars Car { get; set; }

        public int KaputStatusId { get; set; }
        public virtual PieceStatus KaputStatus { get; set; }

        public int TavanStatusId { get; set; }
        public virtual PieceStatus TavanStatus { get; set; }

        public int BagajStatusId { get; set; }
        public virtual PieceStatus BagajStatus { get; set; }

        public int SolOnKapıStatusId { get; set; }
        public virtual PieceStatus SolOnKapıStatus { get; set; }

        public int SagOnKapıStatusId { get; set; }
        public virtual PieceStatus SagOnKapıStatus { get; set; }

        public int SolArkaKapıStatusId { get; set; }
        public virtual PieceStatus SolArkaKapıStatus { get; set; }

        public int SagArkaKapıStatusId { get; set; }
        public virtual PieceStatus SagArkaKapıStatus { get; set; }

        public int SolOnCamurlukStatusId { get; set; }
        public virtual PieceStatus SolOnCamurlukStatus { get; set; }

        public int SagOnCamurlukStatusId { get; set; }
        public virtual PieceStatus SagOnCamurlukStatus { get; set; }

        public int SolArkaCamurlukStatusId { get; set; }
        public virtual PieceStatus SolArkaCamurlukStatus { get; set; }

        public int SagArkaCamurlukStatusId { get; set; }
        public virtual PieceStatus SagArkaCamurlukStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
