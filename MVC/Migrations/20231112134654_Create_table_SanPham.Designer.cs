﻿// <auto-generated />
using MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231112134654_Create_table_SanPham")]
    partial class Create_table_SanPham
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("MVC.Models.KhachHang", b =>
                {
                    b.Property<string>("IdKH")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdKH");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("MVC.Models.NhanVien", b =>
                {
                    b.Property<string>("IdNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AgeNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdNV");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("MVC.Models.SanPham", b =>
                {
                    b.Property<string>("IdSP")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameSP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberSP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PriceSP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdSP");

                    b.ToTable("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
