using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class Store : DbContext
{
    public Store()
    {
    }

    public Store(DbContextOptions<Store> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<CheckProduct> CheckProducts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientCardService> ClientCardServices { get; set; }

    public virtual DbSet<ClientProduct> ClientProducts { get; set; }

    public virtual DbSet<ClientService> ClientServices { get; set; }

    public virtual DbSet<ContactInfomation> ContactInfomations { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierProduct> SupplierProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Server=DESKTOP-JKDGH8A\\SQLEXPRESS;Database=ElctronicsStore;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("Card");

            entity.Property(e => e.CardId)
                .ValueGeneratedNever()
                .HasColumnName("cardID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.CreationDate).HasColumnName("creationDate");
            entity.Property(e => e.DiscountRate)
                .HasColumnType("decimal(4, 1)")
                .HasColumnName("discountRate");
            entity.Property(e => e.TotalAmountPurchase)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("money")
                .HasColumnName("totalAmountPurchase");

            /*entity.HasOne(d => d.Customer).WithMany(p => p.Cards)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_Client");*/
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("categoryID");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity.ToTable("Check");

            entity.Property(e => e.CheckId)
                .ValueGeneratedNever()
                .HasColumnName("checkID");
            entity.Property(e => e.CardId).HasColumnName("cardID");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Time)
                .HasColumnType("time(0)")
                .HasColumnName("time");
            entity.Property(e => e.StaffId).HasColumnName("staffID");


           /* entity.HasOne(d => d.Card).WithMany(p => p.Checks)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("FK_Check_Card");
*/
            /*entity.HasOne(d => d.Staff).WithMany(p => p.Checks)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Check_Staff");
 */       });

        modelBuilder.Entity<CheckProduct>(entity =>
        {
            entity.ToTable("CheckProduct");

            entity.Property(e => e.CheckProductId)
                .ValueGeneratedNever()
                .HasColumnName("CheckProductID");
            entity.Property(e => e.CheckId).HasColumnName("checkID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");

            /*entity.HasOne(d => d.Check).WithMany(p => p.CheckProducts)
                .HasForeignKey(d => d.CheckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckProduct_Check");

            entity.HasOne(d => d.Product).WithMany(p => p.CheckProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CheckProduct_Product");*/
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("clientID");
            entity.Property(e => e.ContactInformationId).HasColumnName("contactInformationID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.ContactInformation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ContactInformationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_ContactInfomation");
        });

        modelBuilder.Entity<ClientCardService>(entity =>
        {
            entity.ToTable("ClientCardService");

            entity.Property(e => e.ClientCardServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ClientCardServiceID");
            entity.Property(e => e.CardId).HasColumnName("cardID");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
/*
            entity.HasOne(d => d.Card).WithMany(p => p.ClientCardServices)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientCardService_ClientCard");
*/
            entity.HasOne(d => d.Service).WithMany(p => p.ClientCardServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientCardService_Service");
        });

        modelBuilder.Entity<ClientProduct>(entity =>
        {
            entity.ToTable("ClientProduct");

            entity.Property(e => e.ClientProductId)
                .ValueGeneratedNever()
                .HasColumnName("ClientProductID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientProducts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientProduct_Client");

           /* entity.HasOne(d => d.Product).WithMany(p => p.ClientProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientProduct_Product");*/
        });

        modelBuilder.Entity<ClientService>(entity =>
        {
            entity.ToTable("ClientService");

            entity.Property(e => e.ClientServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ClientServiceID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientServices)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientService_Client");

            entity.HasOne(d => d.Service).WithMany(p => p.ClientServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientService_Service");
        });

        modelBuilder.Entity<ContactInfomation>(entity =>
        {
            entity.HasKey(e => e.ContactInformationId);

            entity.ToTable("ContactInfomation");

            entity.Property(e => e.ContactInformationId)
                .ValueGeneratedNever()
                .HasColumnName("contactInformationID");
            entity.Property(e => e.Address)
                .HasMaxLength(70)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId)
                .ValueGeneratedNever()
                .HasColumnName("enrollmentID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("dateTime");
            entity.Property(e => e.Device)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("device");
            //entity.Property(e => e.StaffId).HasColumnName("staffID");

            entity.HasOne(d => d.Client).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollment_Client");

            /*entity.HasOne(d => d.Staff).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollment_Staff");*/
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.PositionId)
                .ValueGeneratedNever()
                .HasColumnName("positionID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SupplierId).HasColumnName("supplierID");

            /*entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatagoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Catagory");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Supplier");*/
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("serviceID");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Materials)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("materials");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("staffID");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("lastName");
            //entity.Property(e => e.ContactInformationId).HasColumnName("contactInformationID");
            entity.Property(e => e.PositionId).HasColumnName("positionID");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Specialization)
                .HasMaxLength(50)
                .HasColumnName("specialization")
                .IsRequired(false);

            /*entity.HasOne(d => d.ContactInformation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.ContactInformationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_ContactInfomation");

            /*entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_Position");*/
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId)
                .ValueGeneratedNever()
                .HasColumnName("supplierID");
            entity.Property(e => e.ContactInformationId).HasColumnName("contactInformationID");
            entity.Property(e => e.Name1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.ContactInformation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.ContactInformationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_ContactInfomation");
        });

        modelBuilder.Entity<SupplierProduct>(entity =>
        {
            entity.ToTable("SupplierProduct");

            entity.Property(e => e.SupplierProductId)
                .ValueGeneratedNever()
                .HasColumnName("SupplierProductID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.SupplierId).HasColumnName("supplierID");

            /*entity.HasOne(d => d.Product).WithMany(p => p.SupplierProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierProduct_Product");
*/
            entity.HasOne(d => d.Supplier).WithMany(p => p.SupplierProducts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierProduct_Supplier");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
