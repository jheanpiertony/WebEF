using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebEF.Models;
using WebEF.Models.Enums;
using WebEF.Servicios;

namespace WebEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IAlmacenadorArchivos almacenadorArchivos;

        public ApplicationDbContext()
        {                
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAlmacenadorArchivos _almacenadorArchivos)
            : base(options)
        {
            almacenadorArchivos = _almacenadorArchivos;
        }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<TarjetaCredito> TarjetasCredito { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<ActorPelicula> ActoresPeliculas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            modelBuilder.Entity<Actor>().ToTable("Actor");
            modelBuilder.Entity<Actor>().ToTable("Actor", "dbo");
            modelBuilder.Entity<Actor>().Property(x => x.Genero).HasColumnName("Genero").IsRequired();
            modelBuilder.Entity<Actor>().Property(x => x.Nombres).HasField("nombres");//Mapeo Flexible
            modelBuilder.Entity<Actor>().Property(x => x.Apellidos).HasField("apellidos");//Mapeo Flexible
            modelBuilder.Entity<Actor>().Property(x => x.EstaBorrado).HasDefaultValue(false);

            #region Metodo seed o Data Seeding
            modelBuilder.Entity<Actor>().HasData(
                    new Actor()
                    {
                        Apellidos = "Schwarzenegger",
                        Genero = Genero.Maculino,
                        FechaNacimiento = new DateTime(1947, 7, 30),
                        Id = 1,
                        Nombres = "Arnold Alois",
                        UrlFoto = "https://localhost:44369/actores/d4af3b8f-391c-4586-a342-f983c58d01ad.jpg",
                    },
                    new Actor()
                    {
                        Apellidos = "Gardenzio Stallone",
                        Genero = Genero.Maculino,
                        FechaNacimiento = new DateTime(1946, 7, 06),
                        Id = 2,
                        Nombres = "Michael Sylvester",
                        UrlFoto = "https://localhost:44369/actores/e094214c-451c-4c6f-b327-2bb57d3f325e.jpg",
                    },
                    new Actor() { Apellidos = "Smith", Genero = Genero.Maculino, FechaNacimiento = new DateTime(1968, 12, 25), Id = 3, Nombres = "Willard Carroll", UrlFoto = "https://localhost:44369/actores/4dc4873f-4925-47be-8ba5-24186c49fa1d.jpg", },
                    new Actor() { Apellidos = "Bradley Pitt", Genero = Genero.Maculino, FechaNacimiento = new DateTime(1963, 12, 18), Id = 4, Nombres = "William", UrlFoto = "https://localhost:44369/actores/d1ee8e66-a352-4ed7-81c2-e5b72df6c2fe.jpg", },
                    new Actor() { Apellidos = "Depp II", Genero = Genero.Maculino, FechaNacimiento = new DateTime(1963, 6, 9), Id = 5, Nombres = "John Christopher", UrlFoto = "https://localhost:44369/actores/c68e4de1-c03a-4273-ae78-485defbb2e13.jpg", },
                    new Actor() { Apellidos = "Cruise Mapother IV", Genero = Genero.Maculino, FechaNacimiento = new DateTime(1962, 7, 3), Id = 6, Nombres = "Thomas", UrlFoto = "https://localhost:44369/actores/7e25a4ef-8527-4ccb-8aa3-92b11be92ee8.jpg", },
                    new Actor() { Apellidos = "Johansson ", Genero = Genero.Femenino, FechaNacimiento = new DateTime(1984, 11, 22), Id = 7, Nombres = "Scarlett Ingrid", UrlFoto = "https://localhost:44369/actores/0de5f560-6243-4af1-aecf-1be43ee68843.jpg", },
                    new Actor() { Apellidos = "Jolie Voight", Genero = Genero.Femenino, FechaNacimiento = new DateTime(1975, 6, 4), Id = 8, Nombres = "Angelina", UrlFoto = "https://localhost:44369/actores/4d0d15be-0c1c-405a-82f0-6450fdbb3ad7.jpg", },
                    new Actor() { Apellidos = "DiCaprio", Genero = Genero.Maculino, FechaNacimiento = new DateTime(1974, 11, 11), Id = 9, Nombres = "Leonardo Wilhelm", UrlFoto = "https://localhost:44369/actores/7c054d24-174f-48b2-ab03-efe842daf8c6.jpg", }
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
                new Direccion() { ActorId = 1, TipoDireccion = TipoDireccion.CasaPrincipal, StringDireccion = "2400 Ocean Front Walk, Santa Monica, CA 90405, Estados Unidos", Id = 1, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.48786465828975, 34.001869735409315)) },
                new Direccion() { ActorId = 1, TipoDireccion = TipoDireccion.CasaCampo, StringDireccion = "10-20 Ocean Park Blvd, Santa Monica, CA 90405, Estados Unidos", Id = 2, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.48464087504118, 34.00107534935633)) },
                new Direccion() { ActorId = 2, TipoDireccion = TipoDireccion.CasaPrincipal, StringDireccion = "2601 Neilson Way, Santa Monica, CA 90405, Estados Unidos", Id = 3, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.48426836052148, 34.00183504240847)) },
                new Direccion() { ActorId = 3, TipoDireccion = TipoDireccion.CasaPrincipal, StringDireccion = "505 Ocean Front Walk, Venice, CA 90291, Estados Unidos", Id = 4, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.47890747059306, 33.99319231438554)) },
                new Direccion() { ActorId = 4, TipoDireccion = TipoDireccion.Oficina, StringDireccion = "2925 Vía Pacheco, Palos Verdes Estates, CA 90274, Estados Unidos", Id = 5, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.41590824340811, 33.76455575018337)) },
                new Direccion() { ActorId = 5, TipoDireccion = TipoDireccion.CasaPrincipal, StringDireccion = "2201 Palos Verdes Dr W, Palos Verdes Estates, CA 90274, Estados Unidos", Id = 6, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.41637029843588, 33.77632336684194)) },
                new Direccion() { ActorId = 6, TipoDireccion = TipoDireccion.CasaCampo, StringDireccion = "27405 Pacific Coast Hwy, Malibu, CA 90265, Estados Unidos", Id = 7, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.76790233479153, 34.02861190637989)) },
                new Direccion() { ActorId = 6, TipoDireccion = TipoDireccion.CasaPrincipal, StringDireccion = "29500 Heathercliff Rd, Malibu, CA 90265, Estados Unidos", Id = 8, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.81417560884593, 34.01512505501538)) },
                new Direccion() { ActorId = 7, TipoDireccion = TipoDireccion.Oficina, StringDireccion = "6801 Hollywood Blvd, Hollywood, CA 90028, Estados Unidos", Id = 9, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.33714672981132, 34.103687290608086)) },
                new Direccion() { ActorId = 8, TipoDireccion = TipoDireccion.CasaPrincipal, StringDireccion = "9355 Burton Way, Beverly Hills, CA 90210, Estados Unidos", Id = 10, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.3975529948541, 34.07264945048141)) },
                new Direccion() { ActorId = 8, TipoDireccion = TipoDireccion.Oficina, StringDireccion = "1 E Colorado Blvd, Pasadena, CA 91105, Estados Unidos", Id = 11, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.14764685662927, 34.147721509785754)) },
                new Direccion() { ActorId = 9, TipoDireccion = TipoDireccion.CasaCampo, StringDireccion = "11117 Victory Blvd, North Hollywood, CA 91606, Estados Unidos", Id = 12, Ubicacion = geometryFactory.CreatePoint(new Coordinate(-118.37274964065146, 34.18725350719182)) }
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

            modelBuilder.Entity<ActorPelicula>()
                .HasKey(x => new
                {
                    x.ActorId,
                    x.PeliculaId
                });

            modelBuilder.Entity<Pelicula>()
                .Property(pt => pt.PrecioTicket)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TarjetaCredito>()
                .HasKey(x => new
                {
                    x.Id,
                    x.CodigoTarjeta,
                });

            modelBuilder.Entity<TarjetaCredito>()
                .Property(x => x.Nrotarjeta)
                .IsFixedLength()
                .HasMaxLength(16);

            modelBuilder.Entity<TarjetaCredito>()
                .Ignore(x => x.ConfirmacionNrotarjeta);

            //Borrado en cascada https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete
            foreach (var foreingKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreingKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Quita conveccion de tablas
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // refs https://docs.microsoft.com/en-us/ef/core/modeling/relational/tables#conventions
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

            modelBuilder.Entity<Actor>()
                .HasQueryFilter(eb => !eb.EstaBorrado);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //Borrado Suave
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                e.Metadata.GetProperties().Any(x => x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Borrado Suave
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                e.Metadata.GetProperties().Any(x => x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
