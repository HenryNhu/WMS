using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WMS_new.Models
{
    public partial class WMS_newContext : DbContext
    {
        public WMS_newContext()
        {
        }

        public WMS_newContext(DbContextOptions<WMS_newContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommitmentTime> CommitmentTimes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DeliveryRequest> DeliveryRequests { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<HistoryOfDeliveryRequest> HistoryOfDeliveryRequests { get; set; } = null!;
        public virtual DbSet<HistoryOfImeiproduct> HistoryOfImeiproducts { get; set; } = null!;
        public virtual DbSet<HistoryOfWarehouse> HistoryOfWarehouses { get; set; } = null!;
        public virtual DbSet<ImeiProduct> ImeiProducts { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Nation> Nations { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleBasePermission> RoleBasePermissions { get; set; } = null!;
        public virtual DbSet<TypeOfProduct> TypeOfProducts { get; set; } = null!;
        public virtual DbSet<TypeOfWarehouse> TypeOfWarehouses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Verify> Verifies { get; set; } = null!;
        public virtual DbSet<Ward> Wards { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=WMS_new;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommitmentTime>(entity =>
            {
                entity.ToTable("CommitmentTime");

                entity.Property(e => e.CommitmentTimeId).HasColumnName("CommitmentTimeID");

                entity.Property(e => e.TimeSlot).HasColumnType("datetime");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.CommitmentTimes)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommitmentTime_Warehouse");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PhoneNumber);

                entity.ToTable("Customer");

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.DetailedAddress).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.WardId).HasColumnName("WardID");
            });

            modelBuilder.Entity<DeliveryRequest>(entity =>
            {
                entity.HasKey(e => e.DeliveryId);

                entity.ToTable("DeliveryRequest");

                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");

                entity.Property(e => e.CommitmentTimeId).HasColumnName("CommitmentTimeID");

                entity.Property(e => e.DeliveryNote).HasMaxLength(255);

                entity.Property(e => e.DeliveryType).HasMaxLength(50);

                entity.Property(e => e.DetailedAddress).HasMaxLength(50);

                entity.Property(e => e.Imei).HasColumnName("IMEI");

                entity.Property(e => e.PhoneNumberCustomer)
                    .HasMaxLength(15)
                    .HasColumnName("PhoneNumber_Customer");

                entity.Property(e => e.WardId).HasColumnName("WardID");

                entity.Property(e => e.WarehouseIdDes).HasColumnName("WarehouseID_Des");

                entity.HasOne(d => d.CommitmentTime)
                    .WithMany(p => p.DeliveryRequests)
                    .HasForeignKey(d => d.CommitmentTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryRequest_CommitmentTime");

                entity.HasOne(d => d.ImeiNavigation)
                    .WithMany(p => p.DeliveryRequests)
                    .HasForeignKey(d => d.Imei)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryRequest_IMEI_Product");

                entity.HasOne(d => d.PhoneNumberCustomerNavigation)
                    .WithMany(p => p.DeliveryRequests)
                    .HasForeignKey(d => d.PhoneNumberCustomer)
                    .HasConstraintName("FK_DeliveryRequest_Customer");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.DeliveryRequests)
                    .HasForeignKey(d => d.WardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryRequest_Ward");

                entity.HasOne(d => d.WarehouseIdDesNavigation)
                    .WithMany(p => p.DeliveryRequests)
                    .HasForeignKey(d => d.WarehouseIdDes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryRequest_Warehouse");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.DistrictName).HasMaxLength(100);

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Province");
            });

            modelBuilder.Entity<HistoryOfDeliveryRequest>(entity =>
            {
                entity.HasKey(e => e.HistoryOfDeliveryRequest1);

                entity.ToTable("HistoryOfDeliveryRequest");

                entity.Property(e => e.HistoryOfDeliveryRequest1).HasColumnName("HistoryOfDeliveryRequest");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");

                entity.Property(e => e.UserIdAutherized).HasColumnName("UserID_Autherized");

                entity.Property(e => e.UserIdUpdate).HasColumnName("UserID_Update");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.HistoryOfDeliveryRequests)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryOfDeliveryRequest_DeliveryRequest");

                entity.HasOne(d => d.UserIdAutherizedNavigation)
                    .WithMany(p => p.HistoryOfDeliveryRequestUserIdAutherizedNavigations)
                    .HasForeignKey(d => d.UserIdAutherized)
                    .HasConstraintName("FK_HistoryOfDeliveryRequest_User1");

                entity.HasOne(d => d.UserIdUpdateNavigation)
                    .WithMany(p => p.HistoryOfDeliveryRequestUserIdUpdateNavigations)
                    .HasForeignKey(d => d.UserIdUpdate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryOfDeliveryRequest_User");
            });

            modelBuilder.Entity<HistoryOfImeiproduct>(entity =>
            {
                entity.ToTable("HistoryOfIMEIProduct");

                entity.Property(e => e.HistoryOfImeiproductId).HasColumnName("HistoryOfIMEIProductID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Imei).HasColumnName("IMEI");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WarehouseIdUpdate).HasColumnName("WarehouseID_Update");

                entity.HasOne(d => d.ImeiNavigation)
                    .WithMany(p => p.HistoryOfImeiproducts)
                    .HasForeignKey(d => d.Imei)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryOfIMEIProduct_IMEI_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HistoryOfImeiproducts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryOfIMEIProduct_User");
            });

            modelBuilder.Entity<HistoryOfWarehouse>(entity =>
            {
                entity.ToTable("HistoryOfWarehouse");

                entity.Property(e => e.HistoryOfWarehouseId).HasColumnName("HistoryOfWarehouseID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HistoryOfWarehouses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryOfWarehouse_User");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.HistoryOfWarehouses)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryOfWarehouse_Warehouse");
            });

            modelBuilder.Entity<ImeiProduct>(entity =>
            {
                entity.HasKey(e => e.Imei);

                entity.ToTable("IMEI_Product");

                entity.Property(e => e.Imei).HasColumnName("IMEI");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.WarehouseIdNow).HasColumnName("WarehouseID_Now");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImeiProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IMEI_Product_Product");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName).HasMaxLength(50);

                entity.Property(e => e.NationId).HasColumnName("NationID");

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.NationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Nation");
            });

            modelBuilder.Entity<Nation>(entity =>
            {
                entity.ToTable("Nation");

                entity.Property(e => e.NationId).HasColumnName("NationID");

                entity.Property(e => e.NationName).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.TypeOfProductId).HasColumnName("TypeOfProductID");

                entity.HasOne(d => d.TypeOfProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeOfProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_TypeOfProduct");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProvinceName).HasMaxLength(100);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Province_Location");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleBasePermission>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleBasePermissions_Role");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleBasePermissions_User");
            });

            modelBuilder.Entity<TypeOfProduct>(entity =>
            {
                entity.ToTable("TypeOfProduct");

                entity.Property(e => e.TypeOfProductId).HasColumnName("TypeOfProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfWarehouse>(entity =>
            {
                entity.ToTable("TypeOfWarehouse");

                entity.Property(e => e.TypeOfWarehouseId).HasColumnName("TypeOfWarehouseID");

                entity.Property(e => e.TypeOfWarehouseName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Avatar).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.WarehouseIdWork).HasColumnName("WarehouseID_Work");

                entity.HasOne(d => d.WarehouseIdWorkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.WarehouseIdWork)
                    .HasConstraintName("FK_User_Warehouse");
            });

            modelBuilder.Entity<Verify>(entity =>
            {
                entity.HasKey(e => e.VerifyCode);

                entity.ToTable("Verify");

                entity.Property(e => e.VerifyCode).ValueGeneratedNever();

                entity.Property(e => e.DeliveryId).HasColumnName("DeliveryID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Verifies)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Verify_DeliveryRequest");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Verifies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Verify_User");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("Ward");

                entity.Property(e => e.WardId).HasColumnName("WardID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.WardName).HasMaxLength(100);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ward_District");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.Property(e => e.DetailedAddress).HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeOfWarehouseId).HasColumnName("TypeOfWarehouseID");

                entity.Property(e => e.WardId).HasColumnName("WardID");

                entity.Property(e => e.WarehouseName).HasMaxLength(50);

                entity.HasOne(d => d.TypeOfWarehouse)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.TypeOfWarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_TypeOfWarehouse");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.WardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_Ward");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
