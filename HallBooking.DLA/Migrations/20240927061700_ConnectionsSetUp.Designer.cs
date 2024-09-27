﻿// <auto-generated />
using System;
using HallBooking.DLA.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HallBooking.DLA.Migrations
{
    [DbContext(typeof(HallBookingContext))]
    [Migration("20240927061700_ConnectionsSetUp")]
    partial class ConnectionsSetUp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingService", b =>
                {
                    b.Property<int>("BookingsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("BookingsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("BookingService");
                });

            modelBuilder.Entity("HallBooking.DLA.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConferenceRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceRoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HallBooking.DLA.Entities.ConferenceRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PriceHour")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ConferenceRooms");
                });

            modelBuilder.Entity("HallBooking.DLA.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BookingService", b =>
                {
                    b.HasOne("HallBooking.DLA.Entities.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HallBooking.DLA.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HallBooking.DLA.Entities.Booking", b =>
                {
                    b.HasOne("HallBooking.DLA.Entities.ConferenceRoom", "ConferenceRoom")
                        .WithMany()
                        .HasForeignKey("ConferenceRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConferenceRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
