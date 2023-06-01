﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vesuvius_MDT.Data;

#nullable disable

namespace Vesuvius_MDT.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230601115956_MadeJunctionTable")]
    partial class MadeJunctionTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AddonOrderItem", b =>
                {
                    b.Property<int>("AddonsAddonId")
                        .HasColumnType("int");

                    b.Property<int>("OrderItemsOrderItemId")
                        .HasColumnType("int");

                    b.HasKey("AddonsAddonId", "OrderItemsOrderItemId");

                    b.HasIndex("OrderItemsOrderItemId");

                    b.ToTable("AddonOrderItem");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Addon", b =>
                {
                    b.Property<int>("AddonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddonId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("AddonId");

                    b.ToTable("Addons");

                    b.HasData(
                        new
                        {
                            AddonId = 1,
                            Name = "Pepperoni",
                            Price = 9.99m
                        },
                        new
                        {
                            AddonId = 2,
                            Name = "Salad",
                            Price = 5.00m
                        },
                        new
                        {
                            AddonId = 3,
                            Name = "Cheese",
                            Price = 6.00m
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "marsmanden1@gmail.com",
                            Name = "Sebastian Møller",
                            PhoneNumber = "4528994940"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "mart377i@gmail.com",
                            Name = "Martin Egeskov",
                            PhoneNumber = "4511223344"
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeTypeId");

                    b.HasIndex("LoginId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            EmailAdress = "marsmanden1@gmail.com",
                            EmployeeName = "Sebastian Møller",
                            EmployeeTypeId = 1,
                            LoginId = 1,
                            PhoneNumber = 28994940
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.EmployeeType", b =>
                {
                    b.Property<int>("EmployeeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeTypeId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeTypeId");

                    b.ToTable("EmployeeTypes");

                    b.HasData(
                        new
                        {
                            EmployeeTypeId = 1,
                            Type = "Manager"
                        },
                        new
                        {
                            EmployeeTypeId = 2,
                            Type = "Chef"
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.FoodCategory", b =>
                {
                    b.Property<int>("FoodCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodCategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FoodCategoryId");

                    b.ToTable("FoodCategories");

                    b.HasData(
                        new
                        {
                            FoodCategoryId = 1,
                            Name = "Breakfast"
                        },
                        new
                        {
                            FoodCategoryId = 2,
                            Name = "Dinner"
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.FoodStatus", b =>
                {
                    b.Property<int>("FoodStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodStatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FoodStatusId");

                    b.ToTable("FoodStatuses");

                    b.HasData(
                        new
                        {
                            FoodStatusId = 1,
                            Status = "Available"
                        },
                        new
                        {
                            FoodStatusId = 2,
                            Status = "In progress"
                        },
                        new
                        {
                            FoodStatusId = 3,
                            Status = "Done"
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoginId");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            LoginId = 1,
                            Password = "Admin2023",
                            Username = "TestUser"
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("MenuItemId");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Bøf af hakket oksekød i briochebolle med salat, pickles, tomat, syltede rødløg og burgerdressing.",
                            FoodCategoryId = 2,
                            InStock = true,
                            Name = "Vesuvius Burger",
                            Price = 139m
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tips")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ServerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            OrderStatusId = 1,
                            ReservationId = 1,
                            ServerId = 1,
                            Tips = 2.50m
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("FoodStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Paid")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("OrderItemId");

                    b.HasIndex("FoodStatusId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            Count = 2,
                            FoodStatusId = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Paid = 140.99m
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderStatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            OrderStatusId = 1,
                            Status = "In Progress"
                        },
                        new
                        {
                            OrderStatusId = 2,
                            Status = "Done"
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerRefId")
                        .HasColumnType("int");

                    b.Property<string>("Extra")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ResevationEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ResevationStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerRefId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerRefId = 1,
                            Extra = "Plads til handikap, tak :)",
                            ReservationDateTime = new DateTime(2023, 6, 1, 13, 59, 56, 437, DateTimeKind.Local).AddTicks(420),
                            ResevationEnd = new DateTime(2023, 6, 1, 18, 59, 56, 437, DateTimeKind.Local).AddTicks(470),
                            ResevationStart = new DateTime(2023, 6, 1, 14, 59, 56, 437, DateTimeKind.Local).AddTicks(460),
                            TableId = 1
                        });
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TableSize")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Location = "Zone 3",
                            TableSize = 2
                        },
                        new
                        {
                            TableId = 2,
                            Location = "Zone 3",
                            TableSize = 4
                        });
                });

            modelBuilder.Entity("AddonOrderItem", b =>
                {
                    b.HasOne("Vesuvius_MDT.Models.Addon", null)
                        .WithMany()
                        .HasForeignKey("AddonsAddonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vesuvius_MDT.Models.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsOrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Employee", b =>
                {
                    b.HasOne("Vesuvius_MDT.Models.EmployeeType", "EmployeeType")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeTypeId");

                    b.HasOne("Vesuvius_MDT.Models.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeType");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.MenuItem", b =>
                {
                    b.HasOne("Vesuvius_MDT.Models.FoodCategory", "FoodCategory")
                        .WithMany("MenuItems")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodCategory");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Order", b =>
                {
                    b.HasOne("Vesuvius_MDT.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vesuvius_MDT.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vesuvius_MDT.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Vesuvius_MDT.Models.Employee", "Server")
                        .WithMany("Orders")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("OrderStatus");

                    b.Navigation("Reservation");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.OrderItem", b =>
                {
                    b.HasOne("Vesuvius_MDT.Models.FoodStatus", "FoodStatus")
                        .WithMany("OrderItems")
                        .HasForeignKey("FoodStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vesuvius_MDT.Models.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemId");

                    b.HasOne("Vesuvius_MDT.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodStatus");

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Reservation", b =>
                {
                    b.HasOne("Vesuvius_MDT.Models.Customer", null)
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Vesuvius_MDT.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerRefId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Vesuvius_MDT.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.EmployeeType", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.FoodCategory", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.FoodStatus", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Vesuvius_MDT.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
