﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(HalkoContext))]
    [Migration("20210919112726_Settlements")]
    partial class Settlements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Core.Entities.Halko.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateBuyed")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateSold")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeviceStateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imei")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("PriceBuyed")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStateId");

                    b.HasIndex("Imei");

                    b.HasIndex("PointId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Core.Entities.Halko.DevicePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BoughtPrice")
                        .HasColumnType("REAL");

                    b.Property<double?>("CameraChangeCost")
                        .HasColumnType("REAL");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<string>("Producer")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ScreenChangeCost")
                        .HasColumnType("REAL");

                    b.Property<double>("SellPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("DevicePrices");
                });

            modelBuilder.Entity("Core.Entities.Halko.DeviceService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("GiveBackDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("GiveBackInfo")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Imei")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerContact")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<double>("OwnerCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PointSubmitDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("ServiceCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("TroubleDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Imei");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("PointId");

                    b.ToTable("DeviceServices");
                });

            modelBuilder.Entity("Core.Entities.Halko.DeviceState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DeviceStates");
                });

            modelBuilder.Entity("Core.Entities.Halko.ParticipantPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Initial")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Core.Entities.Halko.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Core.Entities.Halko.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Core.Entities.Halko.Settlement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessoryAmountBilans")
                        .HasColumnType("INTEGER");

                    b.Property<double>("BilansTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("DayBilans")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("DayBilansInCart")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("DayBilansInCash")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("MonthBilansInCart")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PhoneAmountBilans")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceAmountBilans")
                        .HasColumnType("INTEGER");

                    b.Property<double>("StartCash")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("Settlements");
                });

            modelBuilder.Entity("Core.Entities.Halko.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EditedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("PointId");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Core.Entities.Halko.TransactionDeleted", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeletedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EditedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("PointId");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("TransactionsDeleted");
                });

            modelBuilder.Entity("Core.Entities.Halko.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("Core.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("Core.Entities.Identity.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("Core.Entities.Identity.UserPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("PointId");

                    b.ToTable("UserPoints");
                });

            modelBuilder.Entity("Core.Entities.Halko.Device", b =>
                {
                    b.HasOne("Core.Entities.Halko.DeviceState", "DeviceState")
                        .WithMany()
                        .HasForeignKey("DeviceStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceState");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("Core.Entities.Halko.DeviceService", b =>
                {
                    b.HasOne("Core.Entities.Halko.ParticipantPoint", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("Core.Entities.Halko.ParticipantPoint", b =>
                {
                    b.HasOne("Core.Entities.Halko.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");
                });

            modelBuilder.Entity("Core.Entities.Halko.ProductCategory", b =>
                {
                    b.HasOne("Core.Entities.Halko.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Core.Entities.Halko.Settlement", b =>
                {
                    b.HasOne("Core.Entities.Halko.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");
                });

            modelBuilder.Entity("Core.Entities.Halko.Transaction", b =>
                {
                    b.HasOne("Core.Entities.Halko.ParticipantPoint", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Point");

                    b.Navigation("ProductCategory");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Core.Entities.Halko.TransactionDeleted", b =>
                {
                    b.HasOne("Core.Entities.Halko.ParticipantPoint", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Halko.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Point");

                    b.Navigation("ProductCategory");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Core.Entities.Identity.UserPoints", b =>
                {
                    b.HasOne("Core.Entities.Identity.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Entities.Identity.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Point");
                });
#pragma warning restore 612, 618
        }
    }
}
