using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KPZ_Lab_7.Models
{
    public partial class SupermarketNetworkDBContext : DbContext
    {
        public SupermarketNetworkDBContext()
        {
        }

        public SupermarketNetworkDBContext(DbContextOptions<SupermarketNetworkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoolRegion> CoolRegions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HighestPayingCustomer> HighestPayingCustomers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RegionsOfNotOne> RegionsOfNotOnes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<ViewRegion> ViewRegions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=5CD110DFXQ\\SQLEXPRESS;Database=SupermarketNetworkDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CoolRegion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("COOL_REGIONS");

                entity.Property(e => e.RegionEmployeeCount).HasColumnName("region_employee_count");

                entity.Property(e => e.RegionHead).HasColumnName("region_head");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("region_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_email");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone");

                entity.Property(e => e.FirstPurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("first_purchase_date");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasIndex(e => new { e.DeliveryDate, e.DeliveryStatus }, "NCIND_DATE_STATUS");

                entity.Property(e => e.DeliveryId)
                    .ValueGeneratedNever()
                    .HasColumnName("delivery_id");

                entity.Property(e => e.DeliveryByEmployee).HasColumnName("delivery_by_employee");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.DeliveryStatus).HasColumnName("delivery_status");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.DeliveryByEmployeeNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.DeliveryByEmployee)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Deliveries_Employee");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Deliveries_Orders");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.EmployeeManagerId).HasColumnName("employee_manager_id");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("employee_name");

                entity.Property(e => e.EmployeePhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("employee_phone");

                entity.Property(e => e.EmployeeRegion).HasColumnName("employee_region");

                entity.Property(e => e.EmployeeRole).HasColumnName("employee_role");

                entity.HasOne(d => d.EmployeeRegionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeRegion)
                    .HasConstraintName("FK_Employee_Regions");

                entity.HasOne(d => d.EmployeeRoleNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeRole)
                    .HasConstraintName("FK_Employee_Roles");
            });

            modelBuilder.Entity<HighestPayingCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("HIGHEST_PAYING_CUSTOMERS");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Bill)
                    .HasColumnType("smallmoney")
                    .HasColumnName("bill");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OdererId);

                entity.Property(e => e.OdererId)
                    .ValueGeneratedNever()
                    .HasColumnName("oderer_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.PayPrice)
                    .HasColumnType("smallmoney")
                    .HasColumnName("pay_price");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Orders_Regions");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("Order_Items");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Items_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Items_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProfuctType).HasColumnName("profuct_type");

                entity.Property(e => e.PrqoductDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prqoduct_description");

                entity.Property(e => e.PrqoductPrice)
                    .HasColumnType("smallmoney")
                    .HasColumnName("prqoduct_price");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.ProfuctTypeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProfuctType)
                    .HasConstraintName("FK_Product_Product_Types");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Product_Suppliers");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("Product_Types");

                entity.Property(e => e.ProductTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_type_id");

                entity.Property(e => e.ProductTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_type_name");

                entity.Property(e => e.ProductTypeRestrictions)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("product_type_restrictions");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasIndex(e => e.RegionName, "INDEX_REGIONS_NAME");

                entity.Property(e => e.RegionId)
                    .ValueGeneratedNever()
                    .HasColumnName("region_id");

                entity.Property(e => e.RegionEmployeeCount).HasColumnName("region_employee_count");

                entity.Property(e => e.RegionHead).HasColumnName("region_head");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("region_name");

                entity.HasOne(d => d.RegionHeadNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.RegionHead)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Regions_Employee");
            });

            modelBuilder.Entity<RegionsOfNotOne>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("REGIONS_OF_NOT_ONE");

                entity.Property(e => e.RegionEmployeeCount).HasColumnName("region_employee_count");

                entity.Property(e => e.RegionHead).HasColumnName("region_head");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("region_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role_name");

                entity.Property(e => e.RoleWage)
                    .HasColumnType("smallmoney")
                    .HasColumnName("role_wage");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever()
                    .HasColumnName("supplier_id");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contact_name");

                entity.Property(e => e.SupplierAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("supplier_address");

                entity.Property(e => e.SupplierEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supplier_email");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supplier_name");

                entity.Property(e => e.SupplierPhone)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("supplier_phone");
            });

            modelBuilder.Entity<ViewRegion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIEW_REGIONS");

                entity.Property(e => e.RegionEmployeeCount).HasColumnName("region_employee_count");

                entity.Property(e => e.RegionHead).HasColumnName("region_head");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("region_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
