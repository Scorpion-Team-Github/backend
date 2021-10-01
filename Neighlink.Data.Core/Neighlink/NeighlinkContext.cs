using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Neighlink.Data.Core.Neighlink.Entities;

#nullable disable

namespace Neighlink.Data.Core.Neighlink
{
    public partial class NeighlinkContext : DbContext
    {
        public NeighlinkContext()
        {
        }

        public NeighlinkContext(DbContextOptions<NeighlinkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Condominiums> Condominiums { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<PaymentCategories> PaymentCategories { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<Polls> Polls { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bills>(entity =>
            {
                entity.HasIndex(e => e.BuildingId, "IX_Bills_BuildingId");

                entity.HasIndex(e => e.CondominiumId, "IX_Bills_CondominiumId");

                entity.HasIndex(e => e.PaymentCategoryId, "IX_Bills_PaymentCategoryId");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.BuildingId);

                entity.HasOne(d => d.Condominium)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CondominiumId);

                entity.HasOne(d => d.PaymentCategory)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PaymentCategoryId);
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.HasIndex(e => e.CondominiumId, "IX_Buildings_CondominiumId");

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Condominium)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CondominiumId);
            });

            modelBuilder.Entity<Condominiums>(entity =>
            {
                entity.HasIndex(e => e.PlanId, "IX_Condominiums_PlanId");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Condominiums)
                    .HasForeignKey(d => d.PlanId);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasIndex(e => e.CondominiumId, "IX_News_CondominiumId");

                entity.HasOne(d => d.Condominium)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CondominiumId);
            });

            modelBuilder.Entity<PaymentCategories>(entity =>
            {
                entity.HasIndex(e => e.CondominiumId, "IX_PaymentCategories_CondominiumId");

                entity.Property(e => e.Descriptions)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Condominium)
                    .WithMany(p => p.PaymentCategories)
                    .HasForeignKey(d => d.CondominiumId);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasIndex(e => e.BillId, "IX_Payments_BillId");

                entity.HasIndex(e => e.UserId, "IX_Payments_UserId");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BillId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Polls>(entity =>
            {
                entity.HasIndex(e => e.CondominiumId, "IX_Polls_CondominiumId");

                entity.HasOne(d => d.Condominium)
                    .WithMany(p => p.Polls)
                    .HasForeignKey(d => d.CondominiumId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.BuildingId, "IX_Users_BuildingId");

                entity.HasIndex(e => e.CondominiumId, "IX_Users_CondominiumId");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BuildingId);

                entity.HasOne(d => d.Condominium)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CondominiumId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
