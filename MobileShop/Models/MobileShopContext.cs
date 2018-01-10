using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobileShop.Models
{
    public partial class MobileShopContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        public MobileShopContext(DbContextOptions<MobileShopContext> abc):base(abc)
            { }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=Azeem-Pc; Database=MobileShop; Trusted_Connection=True; User Id=sa; Password=pakistan");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerCode);

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasColumnName("CNIC")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("date");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryCode);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("date");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.HasIndex(e => e.Iemino)
                    .HasName("UK_IEMINo")
                    .IsUnique();

                entity.HasIndex(e => e.SerialNo)
                    .HasName("UK_SerialNo")
                    .IsUnique();

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Iemino)
                    .HasColumnName("IEMINo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("date");

                entity.HasOne(d => d.CategoryCodeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryCode)
                    .HasConstraintName("FK_Products_ProductCategory");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.Tdate).HasColumnType("date");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("FK_Purchase_Products");

                entity.HasOne(d => d.VendorCodeNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.VendorCode)
                    .HasConstraintName("FK_Purchase_Vendors");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Tdate).HasColumnType("date");

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.CustomerCode)
                    .HasConstraintName("FK_Sale_Customers");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("FK_Sale_Products");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("date");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasKey(e => e.VendorCode);

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasColumnName("CNIC")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("date");
            });
        }
    }
}
