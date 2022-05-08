using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce_App.Models
{
    public partial class ECommerceAppContext : DbContext
    {
        public ECommerceAppContext()
        {
        }

        public ECommerceAppContext(DbContextOptions<ECommerceAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-SIJ9TPCE;Initial Catalog=ECommerce App;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__carts__2EF52A2734E63B18");

                entity.ToTable("carts");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__carts__customer___4AB81AF0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__carts__product_i__49C3F6B7");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__categori__D54EE9B46D17968B");

                entity.ToTable("categories");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isactive).HasColumnName("isactive");
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.ColorId)
                    .HasName("PK__colors__1143CECB30D14613");

                entity.ToTable("colors");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Isactive).HasColumnName("isactive");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__customer__CD65CB854A53F3C2");

                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasColumnName("customer_address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerContact)
                    .HasColumnName("customer_contact")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customer_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPassword)
                    .HasColumnName("customer_password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPostalcode).HasColumnName("customer_postalcode");

                entity.Property(e => e.CustomerRole).HasColumnName("customer_role");

                entity.Property(e => e.CustomerUsername)
                    .HasColumnName("customer_username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Isactive).HasColumnName("isactive");
            });

            modelBuilder.Entity<Offers>(entity =>
            {
                entity.HasKey(e => e.Offerid)
                    .HasName("PK__offers__58871E9853EF8207");

                entity.ToTable("offers");

                entity.Property(e => e.Offerid).HasColumnName("offerid");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Offerimage)
                    .IsRequired()
                    .HasColumnName("offerimage")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__orders__4659622963C0C9BB");

                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__orders__customer__4D94879B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__orders__product___4E88ABD4");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__47027DF518B94C24");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.DiscountDescription)
                    .HasColumnName("discount_description")
                    .IsUnicode(false);

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductColorId).HasColumnName("product_color_id");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("product_description")
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage)
                    .HasColumnName("product_image")
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.ProductSupplierId).HasColumnName("product_supplier_id");

                entity.Property(e => e.Reviews)
                    .HasColumnName("reviews")
                    .IsUnicode(false);

                entity.Property(e => e.UnitsInStock).HasColumnName("units_in_stock");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK__Products__produc__2D27B809");

                entity.HasOne(d => d.ProductColor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductColorId)
                    .HasConstraintName("FK__Products__produc__2E1BDC42");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .HasConstraintName("FK__Products__produc__2F10007B");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__supplier__6EE594E856C0A228");

                entity.ToTable("suppliers");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierAddress)
                    .HasColumnName("supplier_address")
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasColumnName("supplier_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
