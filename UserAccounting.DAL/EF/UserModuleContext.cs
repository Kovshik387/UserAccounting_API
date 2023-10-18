using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserAccounting.DAL.Entity;

namespace UserAccounting.DAL;

public partial class UserModuleContext : DbContext
{
    public UserModuleContext()
    {
    }

    public UserModuleContext(DbContextOptions<UserModuleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserLoginData> UserLoginData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<UserLoginData>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("user_login_data_pkey");

            entity.ToTable("user_login_data");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Loginname)
                .HasMaxLength(50)
                .HasColumnName("loginname");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(250)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Role).HasColumnName("role");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.UserLoginData)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_login_data_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
