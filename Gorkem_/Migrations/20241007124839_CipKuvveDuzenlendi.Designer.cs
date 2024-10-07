﻿// <auto-generated />
using System;
using Gorkem_.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gorkem_.Migrations
{
    [DbContext(typeof(GorkemDbContext))]
    [Migration("20241007124839_CipKuvveDuzenlendi")]
    partial class CipKuvveDuzenlendi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Askerlik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_Askerliks");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Birim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_Birims");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Brans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_Branss");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Cins", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_Cinss");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_IdareciDurum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_IdareciDurum");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Irk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_Irks");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_KopekDurumu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_KopekDurumus");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_KopekTuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_KopekTurus");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_OgrenimDurumu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UT_IdareciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UT_IdareciId");

                    b.ToTable("KT_OgrenimDurumus");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Rutbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("KT_Rutbes");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_YabanciDil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UT_IdareciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UT_IdareciId");

                    b.ToTable("KT_YabanciDils");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Idareci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<int>("AskerlikId")
                        .HasColumnType("int");

                    b.Property<int>("BirimId")
                        .HasColumnType("int");

                    b.Property<int>("BransId")
                        .HasColumnType("int");

                    b.Property<string>("CepTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdareciDurumId")
                        .HasColumnType("int");

                    b.Property<int>("RutbeId")
                        .HasColumnType("int");

                    b.Property<int>("Sicil")
                        .HasColumnType("int");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AskerlikId");

                    b.HasIndex("BirimId");

                    b.HasIndex("BransId");

                    b.HasIndex("IdareciDurumId");

                    b.HasIndex("RutbeId");

                    b.ToTable("UT_Idarecis");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_IdareciKopekleri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<int>("IdareciId")
                        .HasColumnType("int");

                    b.Property<int>("KopekId")
                        .HasColumnType("int");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdareciId");

                    b.HasIndex("KopekId");

                    b.ToTable("UT_IdareciKopekleri");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<int>("BirimId")
                        .HasColumnType("int");

                    b.Property<int>("BransId")
                        .HasColumnType("int");

                    b.Property<string>("CipNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("IrkId")
                        .HasColumnType("int");

                    b.Property<bool>("Karar")
                        .HasColumnType("bit");

                    b.Property<string>("KopekAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KopekTuruId")
                        .HasColumnType("int");

                    b.Property<string>("KuvveNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NihaiKanaat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.Property<string>("YapilanIslem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BirimId");

                    b.HasIndex("BransId");

                    b.HasIndex("IrkId");

                    b.HasIndex("KopekTuruId");

                    b.ToTable("UT_Kopek_Kopeks");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek_Hibe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdiSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HibeEdilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("TelefonNumarasi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UT_Kopek_Hibes");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek_SatinAlma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdiSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SatinAlmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("TelefonNumarasi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UT_Kopek_SatinAlmas");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek_Uretim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnneKopekRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BabaKopekRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KopekRef")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UT_Kopek_Uretims");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_OgrenimDurumu", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.UT_Idareci", null)
                        .WithMany("OgrenimDurumu")
                        .HasForeignKey("UT_IdareciId");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_YabanciDil", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.UT_Idareci", null)
                        .WithMany("YabanciDil")
                        .HasForeignKey("UT_IdareciId");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Idareci", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.KT_Askerlik", "Askerlik")
                        .WithMany()
                        .HasForeignKey("AskerlikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_Birim", "Birim")
                        .WithMany()
                        .HasForeignKey("BirimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_Brans", "Brans")
                        .WithMany()
                        .HasForeignKey("BransId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_IdareciDurum", "IdareciDurum")
                        .WithMany()
                        .HasForeignKey("IdareciDurumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_Rutbe", "Rutbe")
                        .WithMany()
                        .HasForeignKey("RutbeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Askerlik");

                    b.Navigation("Birim");

                    b.Navigation("Brans");

                    b.Navigation("IdareciDurum");

                    b.Navigation("Rutbe");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_IdareciKopekleri", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.UT_Idareci", "Idareci")
                        .WithMany("Kopek")
                        .HasForeignKey("IdareciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.UT_Kopek", "Kopek")
                        .WithMany("Idareci")
                        .HasForeignKey("KopekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idareci");

                    b.Navigation("Kopek");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.KT_Birim", "Birim")
                        .WithMany()
                        .HasForeignKey("BirimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_Brans", "Brans")
                        .WithMany()
                        .HasForeignKey("BransId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_Irk", "Irk")
                        .WithMany()
                        .HasForeignKey("IrkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_KopekTuru", "KopekTuru")
                        .WithMany()
                        .HasForeignKey("KopekTuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birim");

                    b.Navigation("Brans");

                    b.Navigation("Irk");

                    b.Navigation("KopekTuru");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Idareci", b =>
                {
                    b.Navigation("Kopek");

                    b.Navigation("OgrenimDurumu");

                    b.Navigation("YabanciDil");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek", b =>
                {
                    b.Navigation("Idareci");
                });
#pragma warning restore 612, 618
        }
    }
}
