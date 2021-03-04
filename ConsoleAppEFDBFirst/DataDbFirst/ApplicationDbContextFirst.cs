using ConsoleAppEFDBFirst.ModelDbFirst;
using ConsoleAppEFDBFirst.ModelDbFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;

namespace ConsoleAppEFDBFirst.DataDbFirst
{
    public partial class ApplicationDbContextFirst : DbContext
    {
        private object geometryFactory;

        public ApplicationDbContextFirst()
        {
        }

        public ApplicationDbContextFirst(DbContextOptions<ApplicationDbContextFirst> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<ActorPelicula> ActorPelicula { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }
        public virtual DbSet<TarjetaCredito> TarjetaCredito { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESARROLLO-33\\SQLEXPRESS; Initial Catalog = WebEFDBFirst; Integrated Security = True;", x => x.UseNetTopologySuite())
                    .EnableSensitiveDataLogging(true)
                    .UseLoggerFactory(LoggerFactory.Create(builder =>
                    {
                        builder
                            .AddFilter((category, level) =>
                                category == DbLoggerCategory.Database.Command.Name
                                && level == LogLevel.Information)
                            .AddConsole();
                    }));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.EstaBorrado).HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<ActorPelicula>()
                .HasKey(x => new
                {
                    x.ActorId,
                    x.PeliculaId
                });

            modelBuilder.Entity<TarjetaCredito>()
                .HasKey(x => new
                {
                    x.Id,
                    x.CodigoTarjeta,
                });
            #region Metodo seed o Data Seeding
            modelBuilder.Entity<Actor>().HasData(
                    new Actor()
                    {
                        Apellidos = "Schwarzenegger",
                        Genero = (int) Genero.Maculino,
                        FechaNacimiento = new DateTime(1947, 7, 30),
                        Id = 1,
                        Nombres = "Arnold Alois",
                        UrlFoto = "https://localhost:44369/actores/d4af3b8f-391c-4586-a342-f983c58d01ad.jpg",
                    },
                    new Actor()
                    {
                        Apellidos = "Gardenzio Stallone",
                        Genero = (int) Genero.Maculino,
                        FechaNacimiento = new DateTime(1946, 7, 06),
                        Id = 2,
                        Nombres = "Michael Sylvester",
                        UrlFoto = "https://localhost:44369/actores/e094214c-451c-4c6f-b327-2bb57d3f325e.jpg",
                    },
                    new Actor() { Apellidos = "Smith", Genero = (int) Genero.Maculino, FechaNacimiento = new DateTime(1968, 12, 25), Id = 3, Nombres = "Willard Carroll", UrlFoto = "https://localhost:44369/actores/4dc4873f-4925-47be-8ba5-24186c49fa1d.jpg", },
                    new Actor() { Apellidos = "Bradley Pitt", Genero = (int) Genero.Maculino, FechaNacimiento = new DateTime(1963, 12, 18), Id = 4, Nombres = "William", UrlFoto = "https://localhost:44369/actores/d1ee8e66-a352-4ed7-81c2-e5b72df6c2fe.jpg", },
                    new Actor() { Apellidos = "Depp II", Genero = (int) Genero.Maculino, FechaNacimiento = new DateTime(1963, 6, 9), Id = 5, Nombres = "John Christopher", UrlFoto = "https://localhost:44369/actores/c68e4de1-c03a-4273-ae78-485defbb2e13.jpg", },
                    new Actor() { Apellidos = "Cruise Mapother IV", Genero = (int) Genero.Maculino, FechaNacimiento = new DateTime(1962, 7, 3), Id = 6, Nombres = "Thomas", UrlFoto = "https://localhost:44369/actores/7e25a4ef-8527-4ccb-8aa3-92b11be92ee8.jpg", },
                    new Actor() { Apellidos = "Johansson ", Genero = (int) Genero.Femenino, FechaNacimiento = new DateTime(1984, 11, 22), Id = 7, Nombres = "Scarlett Ingrid", UrlFoto = "https://localhost:44369/actores/0de5f560-6243-4af1-aecf-1be43ee68843.jpg", },
                    new Actor() { Apellidos = "Jolie Voight", Genero = (int) Genero.Femenino, FechaNacimiento = new DateTime(1975, 6, 4), Id = 8, Nombres = "Angelina", UrlFoto = "https://localhost:44369/actores/4d0d15be-0c1c-405a-82f0-6450fdbb3ad7.jpg", },
                    new Actor() { Apellidos = "DiCaprio", Genero = (int) Genero.Maculino, FechaNacimiento = new DateTime(1974, 11, 11), Id = 9, Nombres = "Leonardo Wilhelm", UrlFoto = "https://localhost:44369/actores/7c054d24-174f-48b2-ab03-efe842daf8c6.jpg", }
                    );
            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 1, Nombre = "Independence Day", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/59c71b76-3b29-45c6-a48c-b7a9e18f92b0.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 2, Nombre = "The Terminator I", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/02485536-d0f0-4235-ab4e-66660dda45e5.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 3, Nombre = "The Terminator II", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/4272bef6-db79-497e-92d6-93107ca7a3b3.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 4, Nombre = "The Terminator III", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/c073e4a4-cb30-4a1a-bde2-611bba4997d8.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 5, Nombre = "The Terminator IV", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/cb6c346a-e35b-4f7b-8eaf-b4c117442a74.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 6, Nombre = "The Terminator V", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/59a4067b-61f0-42d0-b6a0-f30eb91bced7.JPG" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 7, Nombre = "Rambo I", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/97bf5dcd-8d95-4c4f-abfc-def818c11325.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 8, Nombre = "Rambo II", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/d7e76157-5eb4-4d0e-a0a1-27af8309d73c.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 9, Nombre = "Titanic", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/0437365e-acb7-4233-9ef5-74bcbfbded2f.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 10, Nombre = "Inception", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/28990cb5-379b-46be-8da4-9a4477114698.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 11, Nombre = "Piratas del Caribe: La venganza de Salazar", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/0b78bd8e-78ec-4bc8-9a6c-a358cf55f067.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 12, Nombre = "Mission: Impossible – Ghost Protocolr", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/6733b610-a22b-4714-aca1-e2299a567ebd.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 13, Nombre = "Captain America: Civil War", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/d1362022-ce18-41e2-b95f-2c709169fae6.jpg" },
                new Pelicula() { EstaCartelera = false, FechaEstreno = new DateTime(2000, 01, 01), Id = 14, Nombre = "Sr. y Sra. Smithr", PrecioTicket = 2000, UrlFoto = "https://localhost:44369/peliculas/ad67aecf-e979-42b5-b60d-6e5d80b9c912.jpg" }
                );
            modelBuilder.Entity<Direccion>().HasData(
                new Direccion() { ActorId = 1, TipoDireccion = (int) TipoDireccion.CasaPrincipal, StringDireccion = "2400 Ocean Front Walk, Santa Monica, CA 90405, Estados Unidos", Id = 1, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.48786465828975, 34.001869735409315)) },
                new Direccion() { ActorId = 1, TipoDireccion = (int) TipoDireccion.CasaCampo, StringDireccion = "10-20 Ocean Park Blvd, Santa Monica, CA 90405, Estados Unidos", Id = 2, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.48464087504118, 34.00107534935633)) },
                new Direccion() { ActorId = 2, TipoDireccion = (int) TipoDireccion.CasaPrincipal, StringDireccion = "2601 Neilson Way, Santa Monica, CA 90405, Estados Unidos", Id = 3, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.48426836052148, 34.00183504240847)) },
                new Direccion() { ActorId = 3, TipoDireccion = (int) TipoDireccion.CasaPrincipal, StringDireccion = "505 Ocean Front Walk, Venice, CA 90291, Estados Unidos", Id = 4, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.47890747059306, 33.99319231438554)) },
                new Direccion() { ActorId = 4, TipoDireccion = (int) TipoDireccion.Oficina, StringDireccion = "2925 Vía Pacheco, Palos Verdes Estates, CA 90274, Estados Unidos", Id = 5, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.41590824340811, 33.76455575018337)) },
                new Direccion() { ActorId = 5, TipoDireccion = (int) TipoDireccion.CasaPrincipal, StringDireccion = "2201 Palos Verdes Dr W, Palos Verdes Estates, CA 90274, Estados Unidos", Id = 6, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.41637029843588, 33.77632336684194)) },
                new Direccion() { ActorId = 6, TipoDireccion = (int) TipoDireccion.CasaCampo, StringDireccion = "27405 Pacific Coast Hwy, Malibu, CA 90265, Estados Unidos", Id = 7, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.76790233479153, 34.02861190637989)) },
                new Direccion() { ActorId = 6, TipoDireccion = (int) TipoDireccion.CasaPrincipal, StringDireccion = "29500 Heathercliff Rd, Malibu, CA 90265, Estados Unidos", Id = 8, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.81417560884593, 34.01512505501538)) },
                new Direccion() { ActorId = 7, TipoDireccion = (int) TipoDireccion.Oficina, StringDireccion = "6801 Hollywood Blvd, Hollywood, CA 90028, Estados Unidos", Id = 9, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.33714672981132, 34.103687290608086)) },
                new Direccion() { ActorId = 8, TipoDireccion = (int) TipoDireccion.CasaPrincipal, StringDireccion = "9355 Burton Way, Beverly Hills, CA 90210, Estados Unidos", Id = 10, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.3975529948541, 34.07264945048141)) },
                new Direccion() { ActorId = 8, TipoDireccion = (int) TipoDireccion.Oficina, StringDireccion = "1 E Colorado Blvd, Pasadena, CA 91105, Estados Unidos", Id = 11, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.14764685662927, 34.147721509785754)) },
                new Direccion() { ActorId = 9, TipoDireccion = (int) TipoDireccion.CasaCampo, StringDireccion = "11117 Victory Blvd, North Hollywood, CA 91606, Estados Unidos", Id = 12, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.37274964065146, 34.18725350719182)) }
                );
            modelBuilder.Entity<TarjetaCredito>().HasData(
                new TarjetaCredito() { ActorId = 1, Id = 1, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO1" },
                new TarjetaCredito() { ActorId = 2, Id = 2, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO2" },
                new TarjetaCredito() { ActorId = 3, Id = 3, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO3" },
                new TarjetaCredito() { ActorId = 4, Id = 4, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO4" },
                new TarjetaCredito() { ActorId = 5, Id = 5, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO5" },
                new TarjetaCredito() { ActorId = 6, Id = 6, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO6" },
                new TarjetaCredito() { ActorId = 7, Id = 7, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO7" },
                new TarjetaCredito() { ActorId = 8, Id = 8, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO8" },
                new TarjetaCredito() { ActorId = 9, Id = 9, Nrotarjeta = "1234567812345678", CodigoTarjeta = "CDO9" }
                );

            modelBuilder.Entity<ActorPelicula>().HasData(
                new ActorPelicula() { ActorId = 1, PeliculaId = 2 },
                new ActorPelicula() { ActorId = 1, PeliculaId = 3 },
                new ActorPelicula() { ActorId = 1, PeliculaId = 4 },
                new ActorPelicula() { ActorId = 1, PeliculaId = 5 },
                new ActorPelicula() { ActorId = 1, PeliculaId = 6 },
                new ActorPelicula() { ActorId = 2, PeliculaId = 7 },
                new ActorPelicula() { ActorId = 2, PeliculaId = 8 },
                new ActorPelicula() { ActorId = 3, PeliculaId = 1 },
                new ActorPelicula() { ActorId = 4, PeliculaId = 14 },
                new ActorPelicula() { ActorId = 5, PeliculaId = 11 },
                new ActorPelicula() { ActorId = 6, PeliculaId = 12 },
                new ActorPelicula() { ActorId = 7, PeliculaId = 13 },
                new ActorPelicula() { ActorId = 8, PeliculaId = 14 },
                new ActorPelicula() { ActorId = 9, PeliculaId = 9 },
                new ActorPelicula() { ActorId = 9, PeliculaId = 10 }
                );
            #endregion
            //modelBuilder.Entity<ActorPelicula>(entity =>
            //{
            //    entity.HasKey(e => new { e.ActorId, e.PeliculaId });

            //    entity.HasIndex(e => e.PeliculaId);

            //    entity.HasOne(d => d.Actor)
            //        .WithMany(p => p.ActorPelicula)
            //        .HasForeignKey(d => d.ActorId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    entity.HasOne(d => d.Pelicula)
            //        .WithMany(p => p.ActorPelicula)
            //        .HasForeignKey(d => d.PeliculaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            //modelBuilder.Entity<Direccion>(entity =>
            //{
            //    entity.HasIndex(e => e.ActorId);

            //    entity.HasOne(d => d.Actor)
            //        .WithMany(p => p.Direccion)
            //        .HasForeignKey(d => d.ActorId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            //modelBuilder.Entity<TarjetaCredito>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.CodigoTarjeta });

            //    entity.HasIndex(e => e.ActorId)
            //        .IsUnique();

            //    entity.Property(e => e.Nrotarjeta).IsFixedLength();

            //    entity.HasOne(d => d.Actor)
            //        .WithOne(p => p.TarjetaCredito)
            //        .HasForeignKey<TarjetaCredito>(d => d.ActorId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
