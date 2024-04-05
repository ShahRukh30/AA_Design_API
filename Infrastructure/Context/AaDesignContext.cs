using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Entitiess;

namespace Infrastructure.Context;

public partial class AaDesignContext : DbContext
{
    public AaDesignContext()
    {
    }

    public AaDesignContext(DbContextOptions<AaDesignContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<DeliveryAdress> DeliveryAdresses { get; set; }

    public virtual DbSet<DeliveryCharge> DeliveryCharges { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductSize> ProductSizes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DevB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A96980D6EAC");

            entity.ToTable("City");

            entity.HasIndex(e => e.CityName, "UQ__City__886159E5E4C31BB1").IsUnique();

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DeliveryAdress>(entity =>
        {
            entity.HasKey(e => e.AdressId).HasName("PK__Delivery__F05DDFE3F7B12CF0");

            entity.ToTable("DeliveryAdress");

            entity.Property(e => e.AdressId).HasColumnName("AdressID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.City).WithMany(p => p.DeliveryAdresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__DeliveryA__CityI__440B1D61");

            entity.HasOne(d => d.State).WithMany(p => p.DeliveryAdresses)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__DeliveryA__State__4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.DeliveryAdresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__DeliveryA__UserI__4222D4EF");
        });

        modelBuilder.Entity<DeliveryCharge>(entity =>
        {
            entity.HasKey(e => e.DeliveryChargeId).HasName("PK__Delivery__373460DC0BB0803D");

            entity.HasIndex(e => e.StateId, "UQ__Delivery__C3BA3B5BB0B0EFCA").IsUnique();

            entity.Property(e => e.DeliveryChargeId).HasColumnName("DeliveryChargeID");
            entity.Property(e => e.DeliveryCharge1)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DeliveryCharge");
            entity.Property(e => e.StateId).HasColumnName("StateID");

            entity.HasOne(d => d.State).WithOne(p => p.DeliveryCharge)
                .HasForeignKey<DeliveryCharge>(d => d.StateId)
                .HasConstraintName("FK__DeliveryC__State__59FA5E80");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF68BA3816");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.DispatchId)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DispatchID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Address).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Orders__AddressI__52593CB8");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06A19D9C2628");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__5629CD9C");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__5535A963");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED1099CB64");

            entity.HasIndex(e => e.ProductName, "UQ__Products__DD5A978A85838AB0").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__ProductI__07B2B1D88028AF42");

            entity.Property(e => e.ProductImageId).HasColumnName("ProductImageID");
            entity.Property(e => e.ImageName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductIm__Produ__4F7CD00D");
        });

        modelBuilder.Entity<ProductSize>(entity =>
        {
            entity.HasKey(e => e.ProductSizeId).HasName("PK__ProductS__9DADF571DCE1D1F2");

            entity.Property(e => e.ProductSizeId).HasColumnName("ProductSizeID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SizeId).HasColumnName("SizeID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductSi__Produ__4BAC3F29");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__ProductSi__SizeI__4CA06362");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AC2D77E8E");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Sizes__83BD095A54C7A4BB");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.Size1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Size");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__States__C3BA3B5A8415C731");

            entity.HasIndex(e => e.StateName, "UQ__States__554763156DB138EE").IsUnique();

            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.StateName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1423B266");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B57FE512").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
