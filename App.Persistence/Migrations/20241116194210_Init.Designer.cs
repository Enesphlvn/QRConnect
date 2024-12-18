﻿// <auto-generated />
using System;
using App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241116194210_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("App.Domain.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("App.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("App.Domain.Entities.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("App.Domain.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("App.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("PurchaseDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("App.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.Domain.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("App.Domain.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("App.Domain.Entities.District", b =>
                {
                    b.HasOne("App.Domain.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("App.Domain.Entities.Event", b =>
                {
                    b.HasOne("App.Domain.Entities.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Entities.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("App.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("App.Domain.Entities.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("App.Domain.Entities.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Entities.Venue", b =>
                {
                    b.HasOne("App.Domain.Entities.City", "City")
                        .WithMany("Venues")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Entities.District", "District")
                        .WithMany("Venues")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("District");
                });

            modelBuilder.Entity("App.Domain.Entities.City", b =>
                {
                    b.Navigation("Districts");

                    b.Navigation("Venues");
                });

            modelBuilder.Entity("App.Domain.Entities.District", b =>
                {
                    b.Navigation("Venues");
                });

            modelBuilder.Entity("App.Domain.Entities.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("App.Domain.Entities.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("App.Domain.Entities.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("App.Domain.Entities.User", b =>
                {
                    b.Navigation("Tickets");

                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("App.Domain.Entities.Venue", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
