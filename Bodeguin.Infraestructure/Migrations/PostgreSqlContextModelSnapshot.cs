﻿// <auto-generated />
using System;
using Bodeguin.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bodeguin.Infraestructure.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    partial class PostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Bodeguin.Domain.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnName("url_image")
                        .HasColumnType("character varying(2500)")
                        .HasMaxLength(2500);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("integer");

                    b.Property<float>("Price")
                        .HasColumnName("price")
                        .HasColumnType("real");

                    b.Property<int>("ProductId")
                        .HasColumnName("producto_id")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("integer");

                    b.Property<int>("VoucherId")
                        .HasColumnName("voucher_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("VoucherId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Price")
                        .HasColumnName("price")
                        .HasColumnType("real");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("integer");

                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnName("url_image")
                        .HasColumnType("character varying(2500)")
                        .HasMaxLength(2500);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnName("direction")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<float>("Latitude")
                        .HasColumnName("latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnName("longitude")
                        .HasColumnType("real");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Ruc")
                        .IsRequired()
                        .HasColumnName("ruc")
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnName("direction")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnName("dni")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstLastName")
                        .IsRequired()
                        .HasColumnName("first_lastname")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsAdmin")
                        .HasColumnName("is_admin")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("SecondLastName")
                        .IsRequired()
                        .HasColumnName("second_lastname")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("create_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnName("modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnName("payment_id")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Detail", b =>
                {
                    b.HasOne("Bodeguin.Domain.Entity.Product", "Product")
                        .WithMany("Details")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bodeguin.Domain.Entity.Voucher", "Voucher")
                        .WithMany("Details")
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Inventory", b =>
                {
                    b.HasOne("Bodeguin.Domain.Entity.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bodeguin.Domain.Entity.Store", "Store")
                        .WithMany("Inventories")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Product", b =>
                {
                    b.HasOne("Bodeguin.Domain.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bodeguin.Domain.Entity.Voucher", b =>
                {
                    b.HasOne("Bodeguin.Domain.Entity.PaymentType", "PaymentType")
                        .WithMany("Vouchers")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bodeguin.Domain.Entity.User", "User")
                        .WithMany("Vouchers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
