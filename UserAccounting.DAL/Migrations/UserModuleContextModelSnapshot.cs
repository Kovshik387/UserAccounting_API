﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserAccounting.DAL;

#nullable disable

namespace UserAccounting.DAL.Migrations
{
    [DbContext(typeof(UserModuleContext))]
    partial class UserModuleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserAccounting.DAL.Entity.Role", b =>
                {
                    b.Property<int>("Roleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("roleid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Roleid"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("type");

                    b.HasKey("Roleid")
                        .HasName("roles_pkey");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("UserAccounting.DAL.Entity.UserLoginData", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Userid"));

                    b.Property<string>("Loginname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("loginname");

                    b.Property<string>("Passwordhash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("passwordhash");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Userid")
                        .HasName("user_login_data_pkey");

                    b.HasIndex("Role");

                    b.ToTable("user_login_data", (string)null);
                });

            modelBuilder.Entity("UserAccounting.DAL.Entity.UserLoginData", b =>
                {
                    b.HasOne("UserAccounting.DAL.Entity.Role", "RoleNavigation")
                        .WithMany("UserLoginData")
                        .HasForeignKey("Role")
                        .IsRequired()
                        .HasConstraintName("user_login_data_role_fkey");

                    b.Navigation("RoleNavigation");
                });

            modelBuilder.Entity("UserAccounting.DAL.Entity.Role", b =>
                {
                    b.Navigation("UserLoginData");
                });
#pragma warning restore 612, 618
        }
    }
}
