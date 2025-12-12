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
        public DbSet<User_Sessions> Users_Sesions { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<DiscountedProducts> DiscountedProducts { get; set; }
        public DbSet<GlobalDiscounts> Global_Discounts { get; set; }
        public DbSet<Clients>Clients { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<InventoryMovement> InventoryMovement { get; set; }
        public DbSet<Sale_Detail> Sale_Details { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Price_History> Price_Histories { get; set; }
        public DbSet<System_Log> System_Log { get; set; }
        public DbSet<Attendance_Log> Attendance_Logs { get; set; }
        public DbSet<User_Schedule> User_Shedules  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USERS
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.User_Id);

                entity.Property(e => e.User_Id)
                      .HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Username)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(e => e.Password)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Rol_Id)
                      .IsRequired();


                entity.Property(e => e.Status)
                      .HasMaxLength(15)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(e => e.Creation_Date)
                      .HasDefaultValueSql("GETDATE()")
                      .ValueGeneratedOnAdd();

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
                entity.Property(e => e.End_Date).IsRequired(false);
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
                entity.Property(e => e.Coupon_Id).HasColumnName("Coupons_Id");
                entity.Property(e => e.Coupons_Code).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.Start_Date).IsRequired();
                entity.Property(e => e.End_Date).IsRequired();
                entity.Property(e => e.Maximum_Use).HasColumnName("Maximum_Use").IsRequired();
                entity.Property(e => e.Time_Used).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
            });

            // COMPANY
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Company_Id);

                entity.Property(e => e.Company_Id).HasColumnName("Company_Id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Nit).HasColumnName("Nit");
                entity.Property(e => e.Address).HasColumnName("Address");
                entity.Property(e => e.Phone_Number).HasColumnName("Phone_Number");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.Slogan).HasColumnName("Slogan");
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
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");
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

            // INVENTORY MOVEMENT
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

            // SALE DETAIL
            modelBuilder.Entity<Sale_Detail>(entity =>
            {
                entity.HasKey(e => e.Detail_Id);
                entity.Property(e => e.Detail_Id).IsRequired();
                entity.Property(e => e.Sale_Id).IsRequired();
                entity.Property(e => e.Product_Id).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Unit_Price).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Discount_Applied).HasColumnType("decimal(18,2)").IsRequired();
                modelBuilder.Entity<Sale_Detail>().ToTable("Sale_Detail");

            });

            // SALES
            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.Sale_Id);
                entity.Property(e => e.Sale_Id).IsRequired();
                entity.Property(e => e.User_Id).IsRequired();
                entity.Property(e => e.Client_Id).IsRequired();
                entity.Property(e => e.Cupon_Id).IsRequired();
                entity.Property(e => e.Sale_Date).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Payment_Method).HasMaxLength(25).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(25).IsRequired();
                entity.Property(e => e.Total_Discount).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Type_Discount).HasMaxLength(25).IsRequired();

            });

            // PRICE HISTORY
            modelBuilder.Entity<Price_History>(entity =>
            {
                entity.ToTable("Price_History"); // asegura coincidencia con SQL

                entity.HasKey(e => e.History_Id);

                entity.Property(e => e.History_Id)
                    .IsRequired();

                entity.Property(e => e.Product_Id)
                    .IsRequired();

                entity.Property(e => e.Previous_Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.New_Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Change_Date)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.User_Id)
                    .IsRequired();

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsRequired(false);
            });

            //System_Log
            modelBuilder.Entity<System_Log>(entity =>
            {
                entity.HasKey(e => e.Id_Logs);

                entity.Property(e => e.Id_Logs)
                    .HasColumnName("Id_Logs");

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id");

                entity.Property(e => e.Acction)
                    .HasColumnName("Acction")
                    .HasMaxLength(15)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .IsRequired();

                entity.Property(e => e.Module)
                    .HasColumnName("Module")
                    .HasMaxLength(25)
                    .IsRequired();
            });

            //Attendance_Log
            modelBuilder.Entity<Attendance_Log>(entity =>
            {
                entity.ToTable("Attendance_Log");

                entity.HasKey(e => e.Attendance_Id);

                entity.Property(e => e.Attendance_Id)
                    .HasColumnName("Attendance_Id")
                    .IsRequired();

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id")
                    .IsRequired();

                entity.Property(e => e.Date)
                    .HasColumnName("Date")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.Start_Date)
                    .HasColumnName("Start_Date")
                    .HasColumnType("time(7)")
                    .IsRequired();

                entity.Property(e => e.End_Date)
                    .HasColumnName("End_Date")
                    .HasColumnType("time(7)");

                entity.Property(e => e.Status)
                    .HasColumnName("Status")
                    .HasMaxLength(15)
                    .IsRequired();

                entity.HasOne(a => a.Users)
                    .WithMany()
                    .HasForeignKey(a => a.User_Id);
            });

            modelBuilder.Entity<User_Schedule>(entity =>
            {
                entity.ToTable("User_Schedule");

                entity.HasKey(e => e.Schedules_Id);

                entity.Property(e => e.Schedules_Id)
                    .HasColumnName("Schedules_Id")
                    .IsRequired();

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id")
                    .IsRequired();

                entity.Property(e => e.Check_In_Time)
                    .HasColumnName("Check_In_Time")
                    .HasColumnType("time(7)")
                    .IsRequired();

                entity.Property(e => e.Check_Out_Time)
                    .HasColumnName("Check_Out_Time")
                    .HasColumnType("time(7)")
                    .IsRequired();

                entity.Property(e => e.Weekday)
                    .HasColumnName("Weekday")
                    .HasMaxLength(15)
                    .IsRequired();

                
            });
        }
    }
}





        
    

