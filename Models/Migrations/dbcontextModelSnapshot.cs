﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RAS.Bootcamp.MVC.NET.Models;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    [DbContext(typeof(dbcontext))]
    partial class dbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Barang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Harga")
                        .HasColumnType("numeric");

                    b.Property<int>("IdPenjual")
                        .HasColumnType("integer");

                    b.Property<string>("Kode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Stok")
                        .HasColumnType("integer");

                    b.Property<string>("imgname")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("IdPenjual");

                    b.ToTable("Barangs");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.ItemTransaksi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Harga")
                        .HasColumnType("numeric");

                    b.Property<int>("IdBarang")
                        .HasColumnType("integer");

                    b.Property<int>("IdTransaksi")
                        .HasColumnType("integer");

                    b.Property<int>("Jumlah")
                        .HasColumnType("integer");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IdBarang");

                    b.HasIndex("IdTransaksi");

                    b.ToTable("ItemTransaksis");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Keranjang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("HargaSatuan")
                        .HasColumnType("numeric");

                    b.Property<int>("IdBarang")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<int>("Jumlah")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdBarang");

                    b.HasIndex("IdUser");

                    b.ToTable("Keranjangs");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Pembeli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AlamatPembeli")
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("NamaPembeli")
                        .HasColumnType("text");

                    b.Property<string>("NoHP")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Pembelis");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Penjual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AlamatToko")
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("NamaToko")
                        .HasColumnType("text");

                    b.Property<string>("NoHP")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Penjuals");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Transaksi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AlamatPengiriman")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("MetodePembayaran")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusBayar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusTransaksi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalHarga")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Transaksis");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Tipe")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Barang", b =>
                {
                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.Penjual", "Penjual")
                        .WithMany("Barangs")
                        .HasForeignKey("IdPenjual")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Penjual");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.ItemTransaksi", b =>
                {
                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.Barang", "Barang")
                        .WithMany()
                        .HasForeignKey("IdBarang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.Transaksi", "Transaksi")
                        .WithMany("ItemTransaksi")
                        .HasForeignKey("IdTransaksi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("Transaksi");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Keranjang", b =>
                {
                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.Barang", "Barang")
                        .WithMany()
                        .HasForeignKey("IdBarang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Pembeli", b =>
                {
                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Penjual", b =>
                {
                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Transaksi", b =>
                {
                    b.HasOne("RAS.Bootcamp.MVC.NET.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Penjual", b =>
                {
                    b.Navigation("Barangs");
                });

            modelBuilder.Entity("RAS.Bootcamp.MVC.NET.Models.Entity.Transaksi", b =>
                {
                    b.Navigation("ItemTransaksi");
                });
#pragma warning restore 612, 618
        }
    }
}
