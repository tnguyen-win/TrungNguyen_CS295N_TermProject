﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGameTrading.Data;

#nullable disable

namespace VideoGameTrading.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231203024040_InitialMySQL")]
    partial class InitialMySQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VideoGameTrading.Models.AppUser", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AppUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VideoGameTrading.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AgeRange")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FromAppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("InCart")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ItemId");

                    b.HasIndex("FromAppUserId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("VideoGameTrading.Models.Item", b =>
                {
                    b.HasOne("VideoGameTrading.Models.AppUser", "From")
                        .WithMany()
                        .HasForeignKey("FromAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("From");
                });
#pragma warning restore 612, 618
        }
    }
}