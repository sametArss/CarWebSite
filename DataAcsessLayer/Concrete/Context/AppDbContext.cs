using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Concrete.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Models> Models { get; set; }
        public DbSet<PieceStatus> PieceStatuses { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<CarImage> CarImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cars – Brand ilişkisi (1-N)
            modelBuilder.Entity<Cars>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cars – Model ilişkisi (1-N)
            modelBuilder.Entity<Cars>()
                .HasOne(c => c.Models)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Expertise – Cars ilişkisi (1-1 veya 1-N olabilir)
                 modelBuilder.Entity<Expertise>()
         .HasOne(e => e.Car)
        .WithOne(c => c.Expertise)
        .HasForeignKey<Expertise>(e => e.CarId)
        .OnDelete(DeleteBehavior.Cascade);


            // Expertise – PieceStatus (her bir parça için)
            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.KaputStatus)
                .WithMany()
                .HasForeignKey(e => e.KaputStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.TavanStatus)
                .WithMany()
                .HasForeignKey(e => e.TavanStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.BagajStatus)
                .WithMany()
                .HasForeignKey(e => e.BagajStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SolOnKapıStatus)
                .WithMany()
                .HasForeignKey(e => e.SolOnKapıStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SagOnKapıStatus)
                .WithMany()
                .HasForeignKey(e => e.SagOnKapıStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SolArkaKapıStatus)
                .WithMany()
                .HasForeignKey(e => e.SolArkaKapıStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SagArkaKapıStatus)
                .WithMany()
                .HasForeignKey(e => e.SagArkaKapıStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SolOnCamurlukStatus)
                .WithMany()
                .HasForeignKey(e => e.SolOnCamurlukStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SagOnCamurlukStatus)
                .WithMany()
                .HasForeignKey(e => e.SagOnCamurlukStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SolArkaCamurlukStatus)
                .WithMany()
                .HasForeignKey(e => e.SolArkaCamurlukStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expertise>()
                .HasOne(e => e.SagArkaCamurlukStatus)
                .WithMany()
                .HasForeignKey(e => e.SagArkaCamurlukStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cars - CarImage ilişkisi (1-Çok)
            modelBuilder.Entity<CarImage>()
                .HasOne(ci => ci.Car)
                .WithMany(c => c.CarImages)
                .HasForeignKey(ci => ci.CarId)
                .OnDelete(DeleteBehavior.Cascade); // Bir araç silindiğinde, ona ait tüm fotoğraflar da silinsin

           
        }

    }
}
