using Back_Proyecto.Models;
using Back_Proyecto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Back_Proyecto.Context
{
    public class CafDataContext : DbContext
    {
        public CafDataContext(DbContextOptions<CafDataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<RolesPermissions> Roles_Permissions { get; set; }
        public DbSet<User_Sessions> User_Sessions { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<DiscountedProducts> DiscountedProducts { get; set; }
        public DbSet<GlobalDiscounts> Global_Discounts { get; set; }
        public DbSet<Clients>Clients { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<InventoryMovement> InventoryMovement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USERS
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.User_Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Rol_Id).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(15).HasConversion<int>();
                entity.Property(e => e.Creation_Date).IsRequired().HasDefaultValueSql("GETDATE()");

                entity.HasOne(u => u.Rol)
                      .WithMany(r => r.Users)
                      .HasForeignKey(u => u.Rol_Id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ROLES
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Rol_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            });

            // PERMISSIONS
            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.Permission_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            });

            // USER SESSIONS
            modelBuilder.Entity<User_Sessions>(entity =>
            {
                entity.HasKey(e => e.Id_Session);
                entity.Property(e => e.User_Id).IsRequired();
                entity.Property(e => e.Token).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Start_Date).IsRequired();
                entity.Property(e => e.End_Date).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);

                entity.HasOne(s => s.User)
                      .WithMany(u => u.Sessions)
                      .HasForeignKey(s => s.User_Id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ROLES PERMISSIONS (Many to Many)
            modelBuilder.Entity<RolesPermissions>(entity =>
            {
                entity.HasKey(rp => new { rp.Role_Id, rp.Permission_Id });

                entity.HasOne(rp => rp.Role)
                      .WithMany(r => r.Roles_Permissions)
                      .HasForeignKey(rp => rp.Role_Id);

                entity.HasOne(rp => rp.Permission)
                      .WithMany(p => p.Roles_Permissions)
                      .HasForeignKey(rp => rp.Permission_Id);
            });

            // CATEGORIES
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasKey(e => e.Category_Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Status).IsRequired();
            });

            // COUPONS
            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.HasKey(e => e.Coupon_Id);
                entity.Property(e => e.Coupons_Code).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Start_Date).IsRequired();
                entity.Property(e => e.End_Date).IsRequired();
                entity.Property(e => e.Maximmum_Use).IsRequired();
                entity.Property(e => e.Time_Used).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
            });

            // COMPANY
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Company_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Phone_Number).IsRequired().HasMaxLength(20).HasColumnName("Phone");
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DiscountedProducts>()
                .HasKey(dp => new { dp.Product_Id, dp.Global_Id });

            modelBuilder.Entity<DiscountedProducts>()
                .HasOne(dp => dp.Product)
                .WithMany(p => p.DiscountedProducts)
                .HasForeignKey(dp => dp.Product_Id);

            modelBuilder.Entity<DiscountedProducts>()
                .HasOne(dp => dp.GlobalDiscount)
                .WithMany(g => g.DiscountedProducts)
                .HasForeignKey(dp => dp.Global_Id);



            // GLOBAL DISCOUNTS
            modelBuilder.Entity<GlobalDiscounts>(entity =>
            {
                entity.ToTable("Global_Discounts");

                entity.HasKey(e => e.Global_Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Start_Date).IsRequired();
                entity.Property(e => e.End_Date).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });

            //CLIENTS
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.Client_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).HasColumnName ("Name");
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150).HasColumnName("Email");
                entity.Property(e => e.Phone_Number).IsRequired().HasMaxLength(20).HasColumnName("Phone_Number");
                entity.Property(e => e.Address).IsRequired().HasMaxLength(200).HasColumnName("Address");
            });
            // PRODUCTS
            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(e => e.Product_Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(25);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,0)");
                entity.Property(e => e.Stock).IsRequired();
                entity.Property(e => e.Min_Stock).IsRequired();
                entity.Property(e => e.Category_Id).IsRequired();
                entity.Property(e => e.Creation_Date).IsRequired();

                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(e => e.Category_Id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Discounts>(entity =>
            {
                entity.HasKey(e => e.Discount_Id);
                entity.Property(e => e.Product_Id).IsRequired().HasColumnName("Product_Id");
                entity.Property(e => e.type).IsRequired().HasMaxLength(15).HasColumnName("Type");
                entity.Property(e => e.Value).IsRequired().HasColumnType("decimal(18, 0)").HasColumnName("Value");
                entity.Property(e => e.Start_Date).IsRequired().HasColumnType("date").HasColumnName("Start_Date");
                entity.Property(e => e.End_Date).IsRequired().HasColumnType("date").HasColumnName("End_Date");
                entity.Property(e => e.Active).IsRequired().HasColumnName("Active");
                entity.Property(e => e.Description).HasMaxLength(50).HasColumnName("Description");

                entity.HasOne(e => e.Products)
                      .WithMany(c => c.Discounts)
                      .HasForeignKey(e => e.Product_Id);
            });

            // DISCOUNTED PRODUCTS
            modelBuilder.Entity<DiscountedProducts>(entity =>
            {
                entity.ToTable("Discounted_Products");

                entity.HasKey(dp => new { dp.Product_Id, dp.Global_Id });

                entity.HasOne(dp => dp.Product)
                      .WithMany(p => p.DiscountedProducts)
                      .HasForeignKey(dp => dp.Product_Id);

                entity.HasOne(dp => dp.GlobalDiscount)
                      .WithMany(g => g.DiscountedProducts)
                      .HasForeignKey(dp => dp.Global_Id);
            });

            modelBuilder.Entity<InventoryMovement>(entity =>
            {
                entity.HasKey(e => e.Movement_Id);

                entity.ToTable("Inventory_Movement");

                entity.Property(e => e.Movement_Id)
                    .HasColumnName("Movement_Id")
                    .IsRequired();

                entity.Property(e => e.Product_Id)
                    .HasColumnName("Product_Id")
                    .IsRequired();

                entity.Property(e => e.Type_Movement)
                    .HasColumnName("Type_Movement")
                    .HasColumnType("nvarchar(20)")
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity")
                    .IsRequired();

                entity.Property(e => e.Reason)
                    .HasColumnName("Reason")
                    .HasColumnType("nvarchar(20)")
                    .IsRequired();

                entity.Property(e => e.Date_Movement)
                    .HasColumnName("Date_Movement")
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id")
                    .IsRequired();

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.Product_Id)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.User_Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });


        }
    }
}
