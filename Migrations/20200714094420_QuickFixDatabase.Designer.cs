﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickFix.Models;

namespace QuickFix.Migrations
{
    [DbContext(typeof(ContextKlasa))]
    [Migration("20200714094420_QuickFixDatabase")]
    partial class QuickFixDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuickFix.Models.Komentar", b =>
                {
                    b.Property<int>("KomentarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("MajstorId")
                        .HasColumnType("int");

                    b.Property<string>("MejlKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SadrzajKomentara")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("KomentarId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("MajstorId");

                    b.ToTable("Komentari");
                });

            modelBuilder.Entity("QuickFix.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnikEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnikIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("KorisnikLokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("KorisnikLozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("KorisnikPrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("KorisnikPrijava")
                        .HasColumnType("int");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("QuickFix.Models.Majstor", b =>
                {
                    b.Property<int>("MajstorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojOcena")
                        .HasColumnType("int");

                    b.Property<string>("MajstorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MajstorIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("MajstorLozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<float>("MajstorOcena")
                        .HasColumnType("real");

                    b.Property<string>("MajstorPrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("MajstorPrijava")
                        .HasColumnType("int");

                    b.Property<int?>("ServisId")
                        .HasColumnType("int");

                    b.HasKey("MajstorId");

                    b.HasIndex("ServisId");

                    b.ToTable("Majstori");
                });

            modelBuilder.Entity("QuickFix.Models.Servis", b =>
                {
                    b.Property<int>("ServisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminLozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("AdminPrijava")
                        .HasColumnType("int");

                    b.Property<string>("ServisAdminGod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServisAdminIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ServisAdminIskustvo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServisAdminPrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ServisIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ServisLokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("ServisId");

                    b.ToTable("Servisi");
                });

            modelBuilder.Entity("QuickFix.Models.Usluga", b =>
                {
                    b.Property<int>("UslugaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CenaUsluge")
                        .HasColumnType("int");

                    b.Property<int?>("MajstorId")
                        .HasColumnType("int");

                    b.Property<string>("NazivUsluge")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("UslugaId");

                    b.HasIndex("MajstorId");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("QuickFix.Models.Zahtev", b =>
                {
                    b.Property<int>("ZahtevId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojOcenaMajstora")
                        .HasColumnType("int");

                    b.Property<string>("EmailKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("MajstorId")
                        .HasColumnType("int");

                    b.Property<float>("OcenaMajstora")
                        .HasColumnType("real");

                    b.Property<int>("OcenjenZahtev")
                        .HasColumnType("int");

                    b.Property<string>("PrezimeKorisnika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrezimeMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StanjeZahteva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UslugaMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZahtevId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("MajstorId");

                    b.ToTable("Zahtevi");
                });

            modelBuilder.Entity("QuickFix.Models.ZahtevNovServis", b =>
                {
                    b.Property<int>("ZahtevNovServisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ZahtevNovServisAdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZahtevNovServisAdminGod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZahtevNovServisAdminIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ZahtevNovServisAdminIskustvo")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ZahtevNovServisAdminLozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ZahtevNovServisAdminPrezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ZahtevNovServisLokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ZahtevNovServisNaziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ZahtevNovServisStanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZahtevNovServisId");

                    b.ToTable("ZahtevZaNovServis");
                });

            modelBuilder.Entity("QuickFix.Models.ZahtevServis", b =>
                {
                    b.Property<int>("ZahtevServisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojOcenaMajstora")
                        .HasColumnType("int");

                    b.Property<string>("EmailMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeServisa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LokacijaServisa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MajstorId")
                        .HasColumnType("int");

                    b.Property<float>("OcenaMajstora")
                        .HasColumnType("real");

                    b.Property<string>("PrezimeMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServisId")
                        .HasColumnType("int");

                    b.Property<string>("StanjeZahteva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UslugaMajstora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZahtevServisId");

                    b.HasIndex("MajstorId");

                    b.HasIndex("ServisId");

                    b.ToTable("ZahteviZaServise");
                });

            modelBuilder.Entity("QuickFix.Models.Komentar", b =>
                {
                    b.HasOne("QuickFix.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.HasOne("QuickFix.Models.Majstor", "Majstor")
                        .WithMany()
                        .HasForeignKey("MajstorId");
                });

            modelBuilder.Entity("QuickFix.Models.Majstor", b =>
                {
                    b.HasOne("QuickFix.Models.Servis", "Servis")
                        .WithMany("ListaMajstora")
                        .HasForeignKey("ServisId");
                });

            modelBuilder.Entity("QuickFix.Models.Usluga", b =>
                {
                    b.HasOne("QuickFix.Models.Majstor", "Majstor")
                        .WithMany("Usluge")
                        .HasForeignKey("MajstorId");
                });

            modelBuilder.Entity("QuickFix.Models.Zahtev", b =>
                {
                    b.HasOne("QuickFix.Models.Korisnik", "Korisnik")
                        .WithMany("ListaZahtevaKorisnika")
                        .HasForeignKey("KorisnikId");

                    b.HasOne("QuickFix.Models.Majstor", "Majstor")
                        .WithMany("ListaZahtevaKorisnika")
                        .HasForeignKey("MajstorId");
                });

            modelBuilder.Entity("QuickFix.Models.ZahtevServis", b =>
                {
                    b.HasOne("QuickFix.Models.Majstor", "Majstor")
                        .WithMany("ListaZahtevaZaServis")
                        .HasForeignKey("MajstorId");

                    b.HasOne("QuickFix.Models.Servis", "Servis")
                        .WithMany("ListaZahtevaZaServis")
                        .HasForeignKey("ServisId");
                });
#pragma warning restore 612, 618
        }
    }
}
