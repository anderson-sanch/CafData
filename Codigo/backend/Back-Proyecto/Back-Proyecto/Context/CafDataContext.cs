using System;
using Back_Proyecto.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Disocunts_Products> Discounts_Products { get; set; }
        public DbSet<Global_Discounts> Global_Discounts { get; set; }
        public DbSet<Clients>Clients { get; set; }
        public DbSet<Products> Products { get; set; }

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
                entity.HasKey(e => e.Category_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(250);
                entity.Property(e => e.status).IsRequired();
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

            // DISCOUNTS PRODUCTS
            modelBuilder.Entity<Disocunts_Products>(entity =>
            {
                entity.HasKey(e => e.Product_Id);
                entity.HasKey(e => e.Global_Id);
            });

            // GLOBAL DISCOUNTS
            modelBuilder.Entity<Global_Discounts>(entity =>
            {
                entity.HasKey(e => e.Global_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20). HasColumnName ("Name");
                entity.Property(e => e.Type).IsRequired().HasMaxLength(20). HasColumnName ("Type");
                entity.Property(e => e.Value).IsRequired().HasColumnName("Value");
                entity.Property(e => e.Start_Date).IsRequired().HasColumnName("Start_Date");
                entity.Property(e => e.End_Date).IsRequired().HasColumnName("End_Date");
                entity.Property(e => e.Status).IsRequired().HasColumnName("Status");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.Client_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).HasColumnName ("Name");
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150).HasColumnName("Email");
                entity.Property(e => e.Phone_Number).IsRequired().HasMaxLength(20).HasColumnName("Phone_Number");
                entity.Property(e => e.Address).IsRequired().HasMaxLength(200).HasColumnName("Address");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Product_Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(25)
                      .HasColumnName("Name");

                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(50) // corregido
                      .HasColumnName("Description");

                entity.Property(e => e.Price)
                      .IsRequired()
                      .HasColumnType("decimal(18, 0)")
                      .HasColumnName("Price"); // corregido

                entity.Property(e => e.Stock)
                      .IsRequired()
                      .HasColumnName("Stock");

                entity.Property(e => e.Min_Stock)
                      .IsRequired()
                      .HasColumnName("Min_Stock");

                entity.Property(e => e.Category_Id)
                      .IsRequired()
                      .HasColumnName("Category_Id");

                entity.Property(e => e.Creation_Date)
                      .IsRequired()
                      .HasColumnType("datetime")
                      .HasColumnName("Creation_Date");

                entity.HasOne(e => e.Categories)
                      .WithMany(c => c.Products)
                      .HasForeignKey(e => e.Category_Id);
            });

        }
    }
}
