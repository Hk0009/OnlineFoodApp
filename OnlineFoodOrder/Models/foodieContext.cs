using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineFoodOrder.Models
{
    public partial class foodieContext : DbContext
    {
        public foodieContext()
        {
        }

        public foodieContext(DbContextOptions<foodieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<FoodCategory> FoodCategories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PersonalInfo> PersonalInfos { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<RestaurantInfo> RestaurantInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=foodie;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Personl)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.PersonlId)
                    .HasConstraintName("FK__cart__PersonlId__403A8C7D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__cart__ProductID__3F466844");
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__FoodCate__19093A0B23B112D3");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.FoodCategories)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__FoodCateg__Resta__29572725");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Personl)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PersonlId)
                    .HasConstraintName("FK__Orders__PersonlI__3C69FB99");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__ProductI__3B75D760");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Payment");

                entity.Property(e => e.Mode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PaymentID");

                entity.HasOne(d => d.Personl)
                    .WithMany()
                    .HasForeignKey(d => d.PersonlId)
                    .HasConstraintName("FK__Payment__Personl__4222D4EF");
            });

            modelBuilder.Entity<PersonalInfo>(entity =>
            {
                entity.HasKey(e => e.PersonlId)
                    .HasName("PK__Personal__7D4A12831B63528A");

                entity.ToTable("PersonalInfo");

                entity.Property(e => e.Adress)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Mobile_No");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__2C3393D0");
            });

            modelBuilder.Entity<RestaurantInfo>(entity =>
            {
                entity.HasKey(e => e.RestaurantId)
                    .HasName("PK__Restaura__87454CB505756D16");

                entity.ToTable("RestaurantInfo");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
