﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WalletApp.Infrastructure.DbContexts;

#nullable disable

namespace WalletApp.Infrastructure.Migrations
{
    [DbContext(typeof(WalletDbContext))]
    [Migration("20231110200326_Creating")]
    partial class Creating
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WalletApp.Domain.DbEntities.TransactionDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorizedUser")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTimeOffset>("ExecutedDay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2023, 11, 10, 20, 3, 26, 181, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("IconUrl")
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("Pending")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Transactions", null, t =>
                        {
                            t.HasCheckConstraint("CK_Type_Range", "\"Type\">=0 or \"Type\"<=1");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("f085a327-9fd5-4cf8-a878-6ed60eae28c9"),
                            AuthorizedUser = "Oleksandr",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "Apple",
                            Pending = true,
                            Sum = 300m,
                            Type = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("f3a67c4e-2c36-4581-9c92-03e9694c82b4"),
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "Steam",
                            Pending = false,
                            Sum = 400m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("0d07e6ad-78a5-4044-a5fd-11373dc50595"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = false,
                            Sum = 318.14m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("d8dec4cd-6de4-4711-ae9e-09e268a0ec1e"),
                            AuthorizedUser = "Oleg",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "Spotify",
                            Pending = false,
                            Sum = 200.4m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("186a852d-6260-412a-97ca-61264d495321"),
                            Description = "Morning transaction",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "Discord",
                            Pending = false,
                            Sum = 318m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("f6fb8e09-f67a-49bd-b121-6c05651a9740"),
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "YouTube",
                            Pending = false,
                            Sum = 200.34m,
                            Type = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("6237c5d2-c58d-4666-bd0a-c2af5a37defa"),
                            AuthorizedUser = "User1",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "Netflix",
                            Pending = false,
                            Sum = 115.52m,
                            Type = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("f82c3e96-7e4e-406e-a248-96866249a786"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = false,
                            Sum = 599.12m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("d0f3b8b4-eab1-4e98-8813-5c3dfa16aeb7"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = true,
                            Sum = 500m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("9a8cb430-bbf7-40eb-8552-3c47530d89c3"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = true,
                            Sum = 250m,
                            Type = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("f1f8bde8-c0b6-4b02-8445-aef65a86eac6"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 3, 4, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = true,
                            Sum = 400.51m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("9ff1eb67-c34c-4bdc-813f-afd671d2ede0"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 3, 3, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = false,
                            Sum = 415.82m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("3d80b86d-b4e3-426a-8ff8-70c5bf28eece"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 3, 2, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = false,
                            Sum = 100m,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("52d059dc-56ac-473a-b8c8-4d12b8545cdc"),
                            Description = "For goods",
                            ExecutedDay = new DateTimeOffset(new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IconUrl = "https://defaultImage.jpg",
                            Name = "IKEA",
                            Pending = false,
                            Sum = 300m,
                            Type = 1,
                            UserId = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
