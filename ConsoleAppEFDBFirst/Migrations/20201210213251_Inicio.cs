using System;
using ConsoleAppEFDBFirst.DataDbFirst.StoredProcedures;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace ConsoleAppEFDBFirst.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    UrlFoto = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<int>(nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorPelicula",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false),
                    PeliculaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorPelicula", x => new { x.ActorId, x.PeliculaId });
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StringDireccion = table.Column<string>(nullable: true),
                    TipoDireccion = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false),
                    Ubicacion = table.Column<Point>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    UrlFoto = table.Column<string>(nullable: true),
                    FechaEstreno = table.Column<DateTime>(nullable: false),
                    EstaCartelera = table.Column<bool>(nullable: false),
                    PrecioTicket = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TarjetaCredito",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CodigoTarjeta = table.Column<string>(nullable: false),
                    Nrotarjeta = table.Column<string>(maxLength: 16, nullable: true),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaCredito", x => new { x.Id, x.CodigoTarjeta });
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Apellidos", "FechaNacimiento", "Genero", "Nombres", "UrlFoto" },
                values: new object[,]
                {
                    { 1, "Schwarzenegger", new DateTime(1947, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Arnold Alois", "https://localhost:44369/actores/d4af3b8f-391c-4586-a342-f983c58d01ad.jpg" },
                    { 2, "Gardenzio Stallone", new DateTime(1946, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Michael Sylvester", "https://localhost:44369/actores/e094214c-451c-4c6f-b327-2bb57d3f325e.jpg" },
                    { 3, "Smith", new DateTime(1968, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Willard Carroll", "https://localhost:44369/actores/4dc4873f-4925-47be-8ba5-24186c49fa1d.jpg" },
                    { 4, "Bradley Pitt", new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "William", "https://localhost:44369/actores/d1ee8e66-a352-4ed7-81c2-e5b72df6c2fe.jpg" },
                    { 5, "Depp II", new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "John Christopher", "https://localhost:44369/actores/c68e4de1-c03a-4273-ae78-485defbb2e13.jpg" },
                    { 6, "Cruise Mapother IV", new DateTime(1962, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Thomas", "https://localhost:44369/actores/7e25a4ef-8527-4ccb-8aa3-92b11be92ee8.jpg" },
                    { 7, "Johansson ", new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Scarlett Ingrid", "https://localhost:44369/actores/0de5f560-6243-4af1-aecf-1be43ee68843.jpg" },
                    { 8, "Jolie Voight", new DateTime(1975, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Angelina", "https://localhost:44369/actores/4d0d15be-0c1c-405a-82f0-6450fdbb3ad7.jpg" },
                    { 9, "DiCaprio", new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Leonardo Wilhelm", "https://localhost:44369/actores/7c054d24-174f-48b2-ab03-efe842daf8c6.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ActorPelicula",
                columns: new[] { "ActorId", "PeliculaId" },
                values: new object[,]
                {
                    { 9, 10 },
                    { 9, 9 },
                    { 8, 14 },
                    { 7, 13 },
                    { 6, 12 },
                    { 5, 11 },
                    { 4, 14 },
                    { 2, 7 },
                    { 2, 8 },
                    { 1, 6 },
                    { 1, 5 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Direccion",
                columns: new[] { "Id", "ActorId", "StringDireccion", "TipoDireccion", "Ubicacion" },
                values: new object[,]
                {
                    { 8, 6, "29500 Heathercliff Rd, Malibu, CA 90265, Estados Unidos", 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.81417560884593 34.015125055015382)") },
                    { 12, 9, "11117 Victory Blvd, North Hollywood, CA 91606, Estados Unidos", 0, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.37274964065146 34.187253507191819)") },
                    { 11, 8, "1 E Colorado Blvd, Pasadena, CA 91105, Estados Unidos", 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.14764685662927 34.147721509785754)") },
                    { 10, 8, "9355 Burton Way, Beverly Hills, CA 90210, Estados Unidos", 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.3975529948541 34.072649450481407)") },
                    { 9, 7, "6801 Hollywood Blvd, Hollywood, CA 90028, Estados Unidos", 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.33714672981132 34.103687290608086)") },
                    { 7, 6, "27405 Pacific Coast Hwy, Malibu, CA 90265, Estados Unidos", 0, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.76790233479153 34.028611906379894)") },
                    { 6, 5, "2201 Palos Verdes Dr W, Palos Verdes Estates, CA 90274, Estados Unidos", 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.41637029843588 33.776323366841943)") },
                    { 5, 4, "2925 Vía Pacheco, Palos Verdes Estates, CA 90274, Estados Unidos", 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.41590824340811 33.764555750183369)") },
                    { 4, 3, "505 Ocean Front Walk, Venice, CA 90291, Estados Unidos", 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.47890747059306 33.993192314385539)") },
                    { 3, 2, "2601 Neilson Way, Santa Monica, CA 90405, Estados Unidos", 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.48426836052148 34.001835042408473)") },
                    { 2, 1, "10-20 Ocean Park Blvd, Santa Monica, CA 90405, Estados Unidos", 0, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.48464087504118 34.001075349356327)") },
                    { 1, 1, "2400 Ocean Front Walk, Santa Monica, CA 90405, Estados Unidos", 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-118.48786465828975 34.001869735409315)") }
                });

            migrationBuilder.InsertData(
                table: "Pelicula",
                columns: new[] { "Id", "EstaCartelera", "FechaEstreno", "Nombre", "PrecioTicket", "UrlFoto" },
                values: new object[,]
                {
                    { 14, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sr. y Sra. Smithr", 2000m, "https://localhost:44369/peliculas/ad67aecf-e979-42b5-b60d-6e5d80b9c912.jpg" },
                    { 13, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Captain America: Civil War", 2000m, "https://localhost:44369/peliculas/d1362022-ce18-41e2-b95f-2c709169fae6.jpg" },
                    { 12, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mission: Impossible – Ghost Protocolr", 2000m, "https://localhost:44369/peliculas/6733b610-a22b-4714-aca1-e2299a567ebd.jpg" },
                    { 11, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piratas del Caribe: La venganza de Salazar", 2000m, "https://localhost:44369/peliculas/0b78bd8e-78ec-4bc8-9a6c-a358cf55f067.jpg" },
                    { 10, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception", 2000m, "https://localhost:44369/peliculas/28990cb5-379b-46be-8da4-9a4477114698.jpg" },
                    { 8, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rambo II", 2000m, "https://localhost:44369/peliculas/d7e76157-5eb4-4d0e-a0a1-27af8309d73c.jpg" },
                    { 9, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic", 2000m, "https://localhost:44369/peliculas/0437365e-acb7-4233-9ef5-74bcbfbded2f.jpg" },
                    { 6, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Terminator V", 2000m, "https://localhost:44369/peliculas/59a4067b-61f0-42d0-b6a0-f30eb91bced7.JPG" },
                    { 5, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Terminator IV", 2000m, "https://localhost:44369/peliculas/cb6c346a-e35b-4f7b-8eaf-b4c117442a74.jpg" },
                    { 4, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Terminator III", 2000m, "https://localhost:44369/peliculas/c073e4a4-cb30-4a1a-bde2-611bba4997d8.jpg" },
                    { 3, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Terminator II", 2000m, "https://localhost:44369/peliculas/4272bef6-db79-497e-92d6-93107ca7a3b3.jpg" },
                    { 2, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Terminator I", 2000m, "https://localhost:44369/peliculas/02485536-d0f0-4235-ab4e-66660dda45e5.jpg" },
                    { 1, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Independence Day", 2000m, "https://localhost:44369/peliculas/59c71b76-3b29-45c6-a48c-b7a9e18f92b0.jpg" },
                    { 7, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rambo I", 2000m, "https://localhost:44369/peliculas/97bf5dcd-8d95-4c4f-abfc-def818c11325.jpg" }
                });

            migrationBuilder.InsertData(
                table: "TarjetaCredito",
                columns: new[] { "Id", "CodigoTarjeta", "ActorId", "Nrotarjeta" },
                values: new object[,]
                {
                    { 8, "CDO8", 8, "1234567812345678" },
                    { 1, "CDO1", 1, "1234567812345678" },
                    { 2, "CDO2", 2, "1234567812345678" },
                    { 3, "CDO3", 3, "1234567812345678" },
                    { 4, "CDO4", 4, "1234567812345678" },
                    { 5, "CDO5", 5, "1234567812345678" },
                    { 6, "CDO6", 6, "1234567812345678" },
                    { 7, "CDO7", 7, "1234567812345678" },
                    { 9, "CDO9", 9, "1234567812345678" }
                });

            migrationBuilder.Sql(RecursosSQLSp.CrearSpActores_SP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "ActorPelicula");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "TarjetaCredito");
            migrationBuilder.Sql(RecursosSQLSp.BorrarSp);
        }
    }
}
