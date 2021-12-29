using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api_AppAuto.Models;

#nullable disable

namespace Api_AppAuto.Models
{
    public partial class Api_AutoContext : DbContext
    {

        public Api_AutoContext(DbContextOptions<Api_AutoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Oder> Oders { get; set; }
        public virtual DbSet<Oderdetail> Oderdetails { get; set; }
        public virtual DbSet<Panel> Panels { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ImgProduct>(entity =>
            {
                entity.Property(e => e.id_product).HasColumnName("Id_product");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Oder>(entity =>
            {
                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Oderdetail>(entity =>
            {
                entity.Property(e => e.IdOder).HasColumnName("id_oder");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Api_AppAuto.Models.Cart> Cart { get; set; }

        public DbSet<Api_AppAuto.Models.Cart> Api_cart { get; set; }

        public DbSet<Api_AppAuto.Models.ImgProduct> ImgProduct { get; set; }

        public DbSet<Api_AppAuto.Models.Videoproduct> Videoproduct { get; set; }

        public DbSet<Api_AppAuto.Models.New> New { get; set; }

        public DbSet<Api_AppAuto.Models.ServiceApp> ServiceApp { get; set; }

        public DbSet<Api_AppAuto.Models.Service> Service { get; set; }

        public DbSet<Api_AppAuto.Models.oderService> oderService { get; set; }

        public DbSet<Api_AppAuto.Models.CheckAdmin> CheckAdmin { get; set; }

        public DbSet<Api_AppAuto.Models.Testcar> Testcar { get; set; }

    }
}
