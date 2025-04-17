﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.DB;

#nullable disable

namespace RestaurantReservation.DB.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    [Migration("20250417022119_CreatePositionEnumInsteadOfEntity")]
    partial class CreatePositionEnumInsteadOfEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johndoe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "12345678"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ruban@gmail.com",
                            FirstName = "Ruba",
                            LastName = "Qa",
                            PhoneNumber = "42345678"
                        },
                        new
                        {
                            Id = 3,
                            Email = "ali@gmail.com",
                            FirstName = "Ali",
                            LastName = "Doe",
                            PhoneNumber = "52345678"
                        },
                        new
                        {
                            Id = 4,
                            Email = "hiba@gmail.com",
                            FirstName = "Hiba",
                            LastName = "Doe",
                            PhoneNumber = "62345678"
                        },
                        new
                        {
                            Id = 5,
                            Email = "mohammad@gmail.com",
                            FirstName = "Mohammad",
                            LastName = "Doe",
                            PhoneNumber = "52345678"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Masa",
                            LastName = "Ahmad",
                            Position = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Khaled",
                            LastName = "Isa",
                            Position = 1,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Jehad",
                            LastName = "Mohammad",
                            Position = 3,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Wael",
                            LastName = "Khaled",
                            Position = 2,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Waleed",
                            LastName = "Awad",
                            Position = 1,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description1",
                            Name = "Home",
                            Price = 10m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description2",
                            Name = "Menu",
                            Price = 10m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description3",
                            Name = "Menu",
                            Price = 10m,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description4",
                            Name = "Menu",
                            Price = 10m,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description5",
                            Name = "Menu",
                            Price = 10m,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.OpeningHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("CloseHour")
                        .HasColumnType("time");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("OpenHour")
                        .HasColumnType("time");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("OpeningHours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CloseHour = new TimeSpan(0, 17, 0, 0, 0),
                            DayOfWeek = 1,
                            OpenHour = new TimeSpan(0, 9, 0, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            CloseHour = new TimeSpan(0, 17, 0, 0, 0),
                            DayOfWeek = 2,
                            OpenHour = new TimeSpan(0, 10, 30, 0, 0),
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            CloseHour = new TimeSpan(0, 17, 0, 0, 0),
                            DayOfWeek = 3,
                            OpenHour = new TimeSpan(0, 9, 0, 0, 0),
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 4,
                            CloseHour = new TimeSpan(0, 20, 0, 0, 0),
                            DayOfWeek = 4,
                            OpenHour = new TimeSpan(0, 9, 0, 0, 0),
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 5,
                            CloseHour = new TimeSpan(0, 21, 0, 0, 0),
                            DayOfWeek = 5,
                            OpenHour = new TimeSpan(0, 9, 0, 0, 0),
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 6,
                            CloseHour = new TimeSpan(0, 18, 0, 0, 0),
                            DayOfWeek = 6,
                            OpenHour = new TimeSpan(0, 10, 0, 0, 0),
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 7,
                            CloseHour = new TimeSpan(0, 18, 0, 0, 0),
                            DayOfWeek = 0,
                            OpenHour = new TimeSpan(0, 8, 0, 0, 0),
                            RestaurantId = 4
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            ReservationId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            ReservationId = 2
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            ReservationId = 3
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            ReservationId = 4
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            ReservationId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            MenuItemId = 2,
                            OrderId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuItemId = 3,
                            OrderId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            MenuItemId = 4,
                            OrderId = 4,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.PaymentDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("PaymentNumber")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("PaymentDetails");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Amount = 4m,
                            PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            PaymentMethod = 0,
                            PaymentNumber = 1
                        },
                        new
                        {
                            OrderId = 2,
                            Amount = 5m,
                            PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            PaymentMethod = 0,
                            PaymentNumber = 2
                        },
                        new
                        {
                            OrderId = 3,
                            Amount = 6m,
                            PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            PaymentMethod = 1,
                            PaymentNumber = 3
                        },
                        new
                        {
                            OrderId = 4,
                            Amount = 7m,
                            PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            PaymentMethod = 1,
                            PaymentNumber = 4
                        },
                        new
                        {
                            OrderId = 5,
                            Amount = 8m,
                            PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            PaymentMethod = 1,
                            PaymentNumber = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            PartySize = 2,
                            ReservationDate = new DateTime(2025, 4, 15, 7, 55, 55, 612, DateTimeKind.Local).AddTicks(8581),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            PartySize = 4,
                            ReservationDate = new DateTime(2025, 4, 20, 7, 46, 45, 612, DateTimeKind.Local),
                            RestaurantId = 2,
                            TableId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            PartySize = 11,
                            ReservationDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            RestaurantId = 3,
                            TableId = 3
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            PartySize = 5,
                            ReservationDate = new DateTime(2025, 3, 20, 7, 46, 45, 612, DateTimeKind.Local),
                            RestaurantId = 4,
                            TableId = 4
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            PartySize = 4,
                            ReservationDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                            RestaurantId = 5,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Nablus",
                            Name = "Restaurant 1",
                            PhoneNumber = "256478912"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Jenin",
                            Name = "Restaurant 2",
                            PhoneNumber = "256478459"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Nablus",
                            Name = "Restaurant 3",
                            PhoneNumber = "123478912"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Jericho",
                            Name = "Restaurant 4",
                            PhoneNumber = "785478912"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Nablus",
                            Name = "Restaurant 5",
                            PhoneNumber = "587478912"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 3,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 4,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 5,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 6,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 7,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.DB.Views.EmployeeWithRestaurantDetails", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RestaurantPhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable((string)null);

                    b.ToView("EmployeeWithRestaurantDetails", (string)null);
                });

            modelBuilder.Entity("RestaurantReservation.DB.Views.ReservationDetails", b =>
                {
                    b.Property<string>("CustomerEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerFirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerLastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerPhone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OpenHours")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("ReservationDetails", (string)null);
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.OpeningHour", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.Restaurant", "Restaurant")
                        .WithMany("OpeningHours")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Order", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantReservation.DB.Models.Entities.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.DB.Models.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.PaymentDetail", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.Order", "Order")
                        .WithOne("PaymentDetail")
                        .HasForeignKey("RestaurantReservation.DB.Models.Entities.PaymentDetail", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RestaurantReservation.DB.Models.Entities.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.DB.Models.Entities.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Table", b =>
                {
                    b.HasOne("RestaurantReservation.DB.Models.Entities.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("PaymentDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("OpeningHours");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.DB.Models.Entities.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
