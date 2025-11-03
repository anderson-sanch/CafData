using System;
using Back_Proyecto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;


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
        public DbSet<Roles_Permissions> Roles_Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.User_Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Username).IsRequired().HasMaxLength(15).HasColumnName("Username");
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50).HasColumnName("Password");
                entity.Property(e => e.Rol_Id).IsRequired().HasColumnName("Rol_Id");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(15).HasColumnName("Status");
                entity.Property(e => e.Creation_Date).IsRequired().HasColumnName("Creation_Date").HasDefaultValueSql("GETDATE()");

                entity.HasOne(u => u.Rol).WithMany(r => r.Users).HasForeignKey(u => u.Rol_Id).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Rol_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100).HasColumnName("Description");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.Permission_Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100).HasColumnName("Description");
            });

            modelBuilder.Entity<User_Sessions>(entity =>
            {
                entity.HasKey(e => e.Id_Session);
                entity.Property(e => e.User_Id).IsRequired().HasColumnName("User_Id");
                entity.Property(e => e.Token).IsRequired().HasMaxLength(500).HasColumnName("Token");
                entity.Property(e => e.Start_Date).IsRequired().HasColumnName("Start_Date");
                entity.Property(e => e.End_Date).IsRequired().HasColumnName("End_Date");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50).HasColumnName("Status");

                entity.HasOne(s => s.User).WithMany(u => u.Sessions).HasForeignKey(s => s.User_Id).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Roles_Permissions>(entity =>
            {
                entity.HasKey(rp => new { rp.Role_Id, rp.Permission_Id });
                entity.HasOne(rp => rp.Role).WithMany(r => r.Roles_Permissions).HasForeignKey(rp => rp.Role_Id);
                entity.HasOne(rp => rp.Permission).WithMany(p => p.Roles_Permissions).HasForeignKey(rp => rp.Permission_Id);
            });
        }
    }
}
