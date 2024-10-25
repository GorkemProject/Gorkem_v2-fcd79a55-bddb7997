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
    [Migration("20241025075118_domalan")]
    partial class domalan
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

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_GorevYeri", b =>
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

                    b.ToTable("KT_GorevYeris");
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

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_KadroIl", b =>
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

                    b.ToTable("KT_KadroIls");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Karar", b =>
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

                    b.ToTable("KT_Karars");
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

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_SecimTest", b =>
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

                    b.ToTable("KT_SecimTests");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Soru", b =>
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

                    b.Property<int>("Puan")
                        .HasColumnType("int");

                    b.Property<int>("SecimTestId")
                        .HasColumnType("int");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SecimTestId");

                    b.ToTable("KT_Sorus");
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

                    b.Property<int>("BransId")
                        .HasColumnType("int");

                    b.Property<string>("CepTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdareciDurumId")
                        .HasColumnType("int");

                    b.Property<int>("KadroIlId")
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

                    b.HasIndex("BransId");

                    b.HasIndex("IdareciDurumId");

                    b.HasIndex("KadroIlId");

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

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Komisyon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<int>("GorevYeriId")
                        .HasColumnType("int");

                    b.Property<string>("KomisyonAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GorevYeriId");

                    b.ToTable("UT_Komisyons");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_KomisyonUyeleri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<string>("CepTelefonu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eposta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GorevUnvani")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GorevYeriId")
                        .HasColumnType("int");

                    b.Property<int?>("Sicil")
                        .HasColumnType("int");

                    b.Property<DateTime>("T_Aktif")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("T_Pasif")
                        .HasColumnType("datetime2");

                    b.Property<string>("TcKimlikNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GorevYeriId");

                    b.ToTable("UT_KomisyonUyeleris");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktifmi")
                        .HasColumnType("bit");

                    b.Property<int?>("AnneKopekId")
                        .HasColumnType("int");

                    b.Property<int?>("BabaKopekId")
                        .HasColumnType("int");

                    b.Property<int>("BransId")
                        .HasColumnType("int");

                    b.Property<int>("Cinsiyet")
                        .HasColumnType("int");

                    b.Property<string>("CipNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("EdinilenKisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EdinilenKisiAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EdinilenKisiTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EdinilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("EdinimSekli")
                        .HasColumnType("int");

                    b.Property<int>("IrkId")
                        .HasColumnType("int");

                    b.Property<int>("KadroIlId")
                        .HasColumnType("int");

                    b.Property<int>("KararId")
                        .HasColumnType("int");

                    b.Property<string>("KopekAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("AnneKopekId");

                    b.HasIndex("BabaKopekId");

                    b.HasIndex("BransId");

                    b.HasIndex("IrkId");

                    b.HasIndex("KadroIlId");

                    b.HasIndex("KararId");

                    b.ToTable("UT_Kopek_Kopeks");
                });

            modelBuilder.Entity("UT_KomisyonUT_KomisyonUyeleri", b =>
                {
                    b.Property<int>("KomisyonId")
                        .HasColumnType("int");

                    b.Property<int>("KomisyonUyeleriId")
                        .HasColumnType("int");

                    b.HasKey("KomisyonId", "KomisyonUyeleriId");

                    b.HasIndex("KomisyonUyeleriId");

                    b.ToTable("UT_KomisyonUT_KomisyonUyeleri");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_OgrenimDurumu", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.UT_Idareci", null)
                        .WithMany("OgrenimDurumu")
                        .HasForeignKey("UT_IdareciId");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.KT_Soru", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.KT_SecimTest", "SecimTest")
                        .WithMany()
                        .HasForeignKey("SecimTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SecimTest");
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

                    b.HasOne("Gorkem_.Context.Entities.KT_KadroIl", "KadroIl")
                        .WithMany()
                        .HasForeignKey("KadroIlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_Rutbe", "Rutbe")
                        .WithMany()
                        .HasForeignKey("RutbeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Askerlik");

                    b.Navigation("Brans");

                    b.Navigation("IdareciDurum");

                    b.Navigation("KadroIl");

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

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Komisyon", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.KT_GorevYeri", "GorevYeri")
                        .WithMany()
                        .HasForeignKey("GorevYeriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GorevYeri");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_KomisyonUyeleri", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.KT_GorevYeri", "GorevYeri")
                        .WithMany()
                        .HasForeignKey("GorevYeriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GorevYeri");
                });

            modelBuilder.Entity("Gorkem_.Context.Entities.UT_Kopek", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.UT_Kopek", "AnneKopek")
                        .WithMany()
                        .HasForeignKey("AnneKopekId");

                    b.HasOne("Gorkem_.Context.Entities.UT_Kopek", "BabaKopek")
                        .WithMany()
                        .HasForeignKey("BabaKopekId");

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

                    b.HasOne("Gorkem_.Context.Entities.KT_KadroIl", "KadroIl")
                        .WithMany()
                        .HasForeignKey("KadroIlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.KT_Karar", "Karar")
                        .WithMany()
                        .HasForeignKey("KararId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnneKopek");

                    b.Navigation("BabaKopek");

                    b.Navigation("Brans");

                    b.Navigation("Irk");

                    b.Navigation("KadroIl");

                    b.Navigation("Karar");
                });

            modelBuilder.Entity("UT_KomisyonUT_KomisyonUyeleri", b =>
                {
                    b.HasOne("Gorkem_.Context.Entities.UT_Komisyon", null)
                        .WithMany()
                        .HasForeignKey("KomisyonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gorkem_.Context.Entities.UT_KomisyonUyeleri", null)
                        .WithMany()
                        .HasForeignKey("KomisyonUyeleriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
