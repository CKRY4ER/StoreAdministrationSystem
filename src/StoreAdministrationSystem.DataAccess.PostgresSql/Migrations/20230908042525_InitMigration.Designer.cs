﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreAdministrationSystem.DataAccess.PostgresSql.Migrator.Context;

#nullable disable

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Migrations
{
    [DbContext(typeof(MigratorDbContext))]
    [Migration("20230908042525_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("order_status");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("total_price");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("AggregateId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Orders.OrderPosition", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<decimal>("PositionPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("position_price");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_positions", (string)null);
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.ProductCategories.ProductCategory", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("product_category_id");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("AggregateId");

                    b.ToTable("product_categories", (string)null);
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)")
                        .HasColumnName("description");

                    b.Property<string>("Parameters")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("parameters");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("product_name");

                    b.Property<string>("ProductPictureUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_picture_url");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("AggregateId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Users.User", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("email");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean")
                        .HasColumnName("is_admin");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AggregateId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Users.UserDocument", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid")
                        .HasColumnName("document_id");

                    b.HasKey("UserId", "DocumentId");

                    b.ToTable("user_documents", (string)null);
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Users.UserSchoppingCartPosition", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<int>("ProductCount")
                        .HasColumnType("integer")
                        .HasColumnName("product_count");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("user_schopping_cart_positions", (string)null);
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Orders.OrderPosition", b =>
                {
                    b.HasOne("StoreAdministrationSystem.Domain.Orders.Order", null)
                        .WithMany("OrderPositions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreAdministrationSystem.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Products.Product", b =>
                {
                    b.HasOne("StoreAdministrationSystem.Domain.ProductCategories.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Users.UserDocument", b =>
                {
                    b.HasOne("StoreAdministrationSystem.Domain.Users.User", null)
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Users.UserSchoppingCartPosition", b =>
                {
                    b.HasOne("StoreAdministrationSystem.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreAdministrationSystem.Domain.Users.User", null)
                        .WithMany("ShoppingCartPositions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Orders.Order", b =>
                {
                    b.Navigation("OrderPositions");
                });

            modelBuilder.Entity("StoreAdministrationSystem.Domain.Users.User", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("ShoppingCartPositions");
                });
#pragma warning restore 612, 618
        }
    }
}
