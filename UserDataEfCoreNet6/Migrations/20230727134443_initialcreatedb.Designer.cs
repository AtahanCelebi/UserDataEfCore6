﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserDataEfCoreNet6.Data;

#nullable disable

namespace UserDataEfCoreNet6.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20230727134443_initialcreatedb")]
    partial class initialcreatedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserDataEfCoreNet6.Data.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Emails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailAddress = "ata@ata.com",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmailAddress = "deneme@outlook.com",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            EmailAddress = "info@gmail.com",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("UserDataEfCoreNet6.Data.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "555 55 55",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            PhoneNumber = "512355",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            PhoneNumber = "33333",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            PhoneNumber = "4444455",
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            PhoneNumber = "990900",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("UserDataEfCoreNet6.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ata"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cem abi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Faruk abi"
                        });
                });

            modelBuilder.Entity("UserDataEfCoreNet6.Data.Email", b =>
                {
                    b.HasOne("UserDataEfCoreNet6.Data.User", "User")
                        .WithOne("Email")
                        .HasForeignKey("UserDataEfCoreNet6.Data.Email", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserDataEfCoreNet6.Data.Phone", b =>
                {
                    b.HasOne("UserDataEfCoreNet6.Data.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserDataEfCoreNet6.Data.User", b =>
                {
                    b.Navigation("Email");

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}
