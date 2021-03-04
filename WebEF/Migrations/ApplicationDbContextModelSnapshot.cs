﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using WebEF.Data;

namespace WebEF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebEF.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaBorrado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genero")
                        .HasColumnName("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlFoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actor","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Schwarzenegger",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1947, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "Arnold Alois",
                            UrlFoto = "https://localhost:44369/actores/d4af3b8f-391c-4586-a342-f983c58d01ad.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "Gardenzio Stallone",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1946, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "Michael Sylvester",
                            UrlFoto = "https://localhost:44369/actores/e094214c-451c-4c6f-b327-2bb57d3f325e.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Apellidos = "Smith",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1968, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "Willard Carroll",
                            UrlFoto = "https://localhost:44369/actores/4dc4873f-4925-47be-8ba5-24186c49fa1d.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Apellidos = "Bradley Pitt",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "William",
                            UrlFoto = "https://localhost:44369/actores/d1ee8e66-a352-4ed7-81c2-e5b72df6c2fe.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Apellidos = "Depp Ii",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "John Christopher",
                            UrlFoto = "https://localhost:44369/actores/c68e4de1-c03a-4273-ae78-485defbb2e13.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Apellidos = "Cruise Mapother Iv",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1962, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "Thomas",
                            UrlFoto = "https://localhost:44369/actores/7e25a4ef-8527-4ccb-8aa3-92b11be92ee8.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Apellidos = "Johansson ",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 0,
                            Nombres = "Scarlett Ingrid",
                            UrlFoto = "https://localhost:44369/actores/0de5f560-6243-4af1-aecf-1be43ee68843.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Apellidos = "Jolie Voight",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1975, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 0,
                            Nombres = "Angelina",
                            UrlFoto = "https://localhost:44369/actores/4d0d15be-0c1c-405a-82f0-6450fdbb3ad7.jpg"
                        },
                        new
                        {
                            Id = 9,
                            Apellidos = "Dicaprio",
                            EstaBorrado = false,
                            FechaNacimiento = new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = 1,
                            Nombres = "Leonardo Wilhelm",
                            UrlFoto = "https://localhost:44369/actores/7c054d24-174f-48b2-ab03-efe842daf8c6.jpg"
                        });
                });

            modelBuilder.Entity("WebEF.Models.ActorPelicula", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "PeliculaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("ActorPelicula");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            PeliculaId = 2
                        },
                        new
                        {
                            ActorId = 1,
                            PeliculaId = 3
                        },
                        new
                        {
                            ActorId = 1,
                            PeliculaId = 4
                        },
                        new
                        {
                            ActorId = 1,
                            PeliculaId = 5
                        },
                        new
                        {
                            ActorId = 1,
                            PeliculaId = 6
                        },
                        new
                        {
                            ActorId = 2,
                            PeliculaId = 7
                        },
                        new
                        {
                            ActorId = 2,
                            PeliculaId = 8
                        },
                        new
                        {
                            ActorId = 3,
                            PeliculaId = 1
                        },
                        new
                        {
                            ActorId = 4,
                            PeliculaId = 14
                        },
                        new
                        {
                            ActorId = 5,
                            PeliculaId = 11
                        },
                        new
                        {
                            ActorId = 6,
                            PeliculaId = 12
                        },
                        new
                        {
                            ActorId = 7,
                            PeliculaId = 13
                        },
                        new
                        {
                            ActorId = 8,
                            PeliculaId = 14
                        },
                        new
                        {
                            ActorId = 9,
                            PeliculaId = 9
                        },
                        new
                        {
                            ActorId = 9,
                            PeliculaId = 10
                        });
                });

            modelBuilder.Entity("WebEF.Models.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("StringDireccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDireccion")
                        .HasColumnType("int");

                    b.Property<Point>("Ubicacion")
                        .HasColumnType("geography");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("Direccion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActorId = 1,
                            StringDireccion = "2400 Ocean Front Walk, Santa Monica, CA 90405, Estados Unidos",
                            TipoDireccion = 1,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.48786465828975 34.001869735409315)")
                        },
                        new
                        {
                            Id = 2,
                            ActorId = 1,
                            StringDireccion = "10-20 Ocean Park Blvd, Santa Monica, CA 90405, Estados Unidos",
                            TipoDireccion = 0,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.48464087504118 34.001075349356327)")
                        },
                        new
                        {
                            Id = 3,
                            ActorId = 2,
                            StringDireccion = "2601 Neilson Way, Santa Monica, CA 90405, Estados Unidos",
                            TipoDireccion = 1,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.48426836052148 34.001835042408473)")
                        },
                        new
                        {
                            Id = 4,
                            ActorId = 3,
                            StringDireccion = "505 Ocean Front Walk, Venice, CA 90291, Estados Unidos",
                            TipoDireccion = 1,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.47890747059306 33.993192314385539)")
                        },
                        new
                        {
                            Id = 5,
                            ActorId = 4,
                            StringDireccion = "2925 Vía Pacheco, Palos Verdes Estates, CA 90274, Estados Unidos",
                            TipoDireccion = 2,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.41590824340811 33.764555750183369)")
                        },
                        new
                        {
                            Id = 6,
                            ActorId = 5,
                            StringDireccion = "2201 Palos Verdes Dr W, Palos Verdes Estates, CA 90274, Estados Unidos",
                            TipoDireccion = 1,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.41637029843588 33.776323366841943)")
                        },
                        new
                        {
                            Id = 7,
                            ActorId = 6,
                            StringDireccion = "27405 Pacific Coast Hwy, Malibu, CA 90265, Estados Unidos",
                            TipoDireccion = 0,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.76790233479153 34.028611906379894)")
                        },
                        new
                        {
                            Id = 8,
                            ActorId = 6,
                            StringDireccion = "29500 Heathercliff Rd, Malibu, CA 90265, Estados Unidos",
                            TipoDireccion = 1,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.81417560884593 34.015125055015382)")
                        },
                        new
                        {
                            Id = 9,
                            ActorId = 7,
                            StringDireccion = "6801 Hollywood Blvd, Hollywood, CA 90028, Estados Unidos",
                            TipoDireccion = 2,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.33714672981132 34.103687290608086)")
                        },
                        new
                        {
                            Id = 10,
                            ActorId = 8,
                            StringDireccion = "9355 Burton Way, Beverly Hills, CA 90210, Estados Unidos",
                            TipoDireccion = 1,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.3975529948541 34.072649450481407)")
                        },
                        new
                        {
                            Id = 11,
                            ActorId = 8,
                            StringDireccion = "1 E Colorado Blvd, Pasadena, CA 91105, Estados Unidos",
                            TipoDireccion = 2,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.14764685662927 34.147721509785754)")
                        },
                        new
                        {
                            Id = 12,
                            ActorId = 9,
                            StringDireccion = "11117 Victory Blvd, North Hollywood, CA 91606, Estados Unidos",
                            TipoDireccion = 0,
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.37274964065146 34.187253507191819)")
                        });
                });

            modelBuilder.Entity("WebEF.Models.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaCartelera")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioTicket")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrlFoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pelicula");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Independence Day",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/59c71b76-3b29-45c6-a48c-b7a9e18f92b0.jpg"
                        },
                        new
                        {
                            Id = 2,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "The Terminator I",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/02485536-d0f0-4235-ab4e-66660dda45e5.jpg"
                        },
                        new
                        {
                            Id = 3,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "The Terminator II",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/4272bef6-db79-497e-92d6-93107ca7a3b3.jpg"
                        },
                        new
                        {
                            Id = 4,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "The Terminator III",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/c073e4a4-cb30-4a1a-bde2-611bba4997d8.jpg"
                        },
                        new
                        {
                            Id = 5,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "The Terminator IV",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/cb6c346a-e35b-4f7b-8eaf-b4c117442a74.jpg"
                        },
                        new
                        {
                            Id = 6,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "The Terminator V",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/59a4067b-61f0-42d0-b6a0-f30eb91bced7.JPG"
                        },
                        new
                        {
                            Id = 7,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Rambo I",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/97bf5dcd-8d95-4c4f-abfc-def818c11325.jpg"
                        },
                        new
                        {
                            Id = 8,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Rambo II",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/d7e76157-5eb4-4d0e-a0a1-27af8309d73c.jpg"
                        },
                        new
                        {
                            Id = 9,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Titanic",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/0437365e-acb7-4233-9ef5-74bcbfbded2f.jpg"
                        },
                        new
                        {
                            Id = 10,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Inception",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/28990cb5-379b-46be-8da4-9a4477114698.jpg"
                        },
                        new
                        {
                            Id = 11,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Piratas del Caribe: La venganza de Salazar",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/0b78bd8e-78ec-4bc8-9a6c-a358cf55f067.jpg"
                        },
                        new
                        {
                            Id = 12,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Mission: Impossible – Ghost Protocolr",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/6733b610-a22b-4714-aca1-e2299a567ebd.jpg"
                        },
                        new
                        {
                            Id = 13,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Captain America: Civil War",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/d1362022-ce18-41e2-b95f-2c709169fae6.jpg"
                        },
                        new
                        {
                            Id = 14,
                            EstaCartelera = false,
                            FechaEstreno = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Sr. y Sra. Smithr",
                            PrecioTicket = 2000m,
                            UrlFoto = "https://localhost:44369/peliculas/ad67aecf-e979-42b5-b60d-6e5d80b9c912.jpg"
                        });
                });

            modelBuilder.Entity("WebEF.Models.TarjetaCredito", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CodigoTarjeta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Nrotarjeta")
                        .HasColumnType("nchar(16)")
                        .IsFixedLength(true)
                        .HasMaxLength(16);

                    b.HasKey("Id", "CodigoTarjeta");

                    b.HasIndex("ActorId")
                        .IsUnique();

                    b.ToTable("TarjetaCredito");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodigoTarjeta = "CDO1",
                            ActorId = 1,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 2,
                            CodigoTarjeta = "CDO2",
                            ActorId = 2,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 3,
                            CodigoTarjeta = "CDO3",
                            ActorId = 3,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 4,
                            CodigoTarjeta = "CDO4",
                            ActorId = 4,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 5,
                            CodigoTarjeta = "CDO5",
                            ActorId = 5,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 6,
                            CodigoTarjeta = "CDO6",
                            ActorId = 6,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 7,
                            CodigoTarjeta = "CDO7",
                            ActorId = 7,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 8,
                            CodigoTarjeta = "CDO8",
                            ActorId = 8,
                            Nrotarjeta = "1234567812345678"
                        },
                        new
                        {
                            Id = 9,
                            CodigoTarjeta = "CDO9",
                            ActorId = 9,
                            Nrotarjeta = "1234567812345678"
                        });
                });

            modelBuilder.Entity("WebEF.Models.ActorPelicula", b =>
                {
                    b.HasOne("WebEF.Models.Actor", "Actor")
                        .WithMany("ActoresPeliculas")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebEF.Models.Pelicula", "Pelicula")
                        .WithMany("ActoresPeliculas")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebEF.Models.Direccion", b =>
                {
                    b.HasOne("WebEF.Models.Actor", "Actor")
                        .WithMany("Direcciones")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WebEF.Models.TarjetaCredito", b =>
                {
                    b.HasOne("WebEF.Models.Actor", "Actor")
                        .WithOne("TarjetaCredito")
                        .HasForeignKey("WebEF.Models.TarjetaCredito", "ActorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
