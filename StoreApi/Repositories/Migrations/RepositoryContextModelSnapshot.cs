﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.EfCore;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoyName = "Demo Category"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoyName = "Demo Category2"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoyName = "Demo Category3"
                        });
                });

            modelBuilder.Entity("Entities.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateTime = new DateTime(2024, 5, 6, 18, 8, 3, 216, DateTimeKind.Local).AddTicks(1494),
                            Description = "Demo Description",
                            Price = 0m,
                            ProductName = "Demo Product Name",
                            Stok = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            DateTime = new DateTime(2024, 5, 6, 18, 8, 3, 216, DateTimeKind.Local).AddTicks(1509),
                            Description = "Demo Description_1",
                            Price = 0m,
                            ProductName = "Demo Product Name_1",
                            Stok = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            DateTime = new DateTime(2024, 5, 6, 18, 8, 3, 216, DateTimeKind.Local).AddTicks(1510),
                            Description = "Demo Description_2",
                            Price = 0m,
                            ProductName = "Demo Product Name_2",
                            Stok = 3
                        });
                });

            modelBuilder.Entity("Entities.Models.Products", b =>
                {
                    b.HasOne("Entities.Models.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Entities.Models.Categories", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
