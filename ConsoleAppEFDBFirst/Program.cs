using ConsoleAppEFDBFirst.DataDbFirst;
using ConsoleAppEFDBFirst.DataDbFirst.StoredProcedures;
using ConsoleAppEFDBFirst.ModelDbFirst;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleAppEFDBFirst
{
	class Program
	{
		static void Main(string[] args)
        {
            //var dbContet = new ApplicationDbContextFirst();

            //var listadoPeliculas = dbContet.Pelicula.OrderByDescending(x => x.Nombre).ToList();

            //var peliculasConActores = dbContet.Pelicula
            //    .Include(x => x.ActorPelicula)
            //    .ThenInclude(x => x.Actor.Direccion)ToList();

            //var queriesAlbitrarios = dbContet.Pelicula.FromSqlRaw(@"SELECT [p].[Id], [p].[EstaCartelera], [p].[FechaEstreno], [p].[Nombre], [p].[PrecioTicket], [p].[UrlFoto] " +
            //    "FROM [Pelicula] AS [p]")
            //    .IgnoreQueryFilters()
            //    .Select(x => new { x.Nombre, x.PrecioTicket }).ToList();

            //var id = 14;
            //using (var contextDos = new ApplicationDbContextFirst())
            //{
            //    var parametros = new SqlParameter("@Id", id);
            //    var pelicula = contextDos.Pelicula.FromSqlRaw("Select * from Pelicula where Id = Id", new SqlParameter[] { parametros })
            //        .FirstOrDefault();
            //}

            //using (var contextDos = new ApplicationDbContextFirst())
            //{
            //    var pelicula = contextDos.Pelicula.FromSqlRaw($"Select * from Pelicula where Id = {id}")
            //        .FirstOrDefault();
            //}

            //using (var contextDos = new ApplicationDbContextFirst())
            //{
            //    var pelicula = contextDos.Pelicula;
            //    if (pelicula.Where(x => x.PrecioTicket <= 2000).Count() >= 2)
            //    {
            //        var anomino = pelicula
            //            .Include(x => x.ActorPelicula)
            //            .ThenInclude(x => x.Actor.Direccion)
            //            .Select(x => new
            //            {
            //                pelicula = x,
            //                Actores = x.ActorPelicula.Where(y => y.Actor.Direccion.Count() > 0).ToList()
            //            }).ToList();
            //    }
            //    else
            //    {
            //        var anonimo = pelicula.ToList();
            //    }
            //}


            //using (var contextDos = new ApplicationDbContextFirst())
            //{
            //    var a = contextDos.Actor.FromSqlRaw(RecursosSQLSp.CrearSp).ToList();
            //    var b = a.OrderBy(x => x.Nombres).ToList();
            //}

            //using (var contextDos = new ApplicationDbContextFirst())
            //{
            //    var a = contextDos.Actor.FromSqlRaw("CrearSpActoresDos_SP").ToList();
            //}

   //         using (var contextDos = new ApplicationDbContextFirst()) 
			//{
			//	//var a = contextDos.Actor
			//	//	.Join(
			//	//	contextDos.ActorPelicula,
			//	//	x => x.Id,
			//	//	y => y.ActorId,
			//	//	(Actor, ActorPelicula) => new{
			//	//		Actor,
			//	//		ActorPelicula,
			//	//	}).Join(
			//	//		contextDos.Pelicula,
			//	//		z => z.ActorPelicula.PeliculaId,
			//	//		w => w.Id,
			//	//		(ActorPelicula, Pelicula) => new{
			//	//			ActorPelicula,
			//	//			Pelicula
			//	//		}).Where(x => x.Pelicula.FechaEstreno <= DateTime.Now).ToList();

			//	//var b = contextDos.Pelicula.Join(
			//	//	contextDos.ActorPelicula, 
			//	//	x => x.Id, 
			//	//	y => y.PeliculaId, 
			//	//	(Pelicula, ActorPelicula) => new { 
			//	//		Pelicula, 
			//	//		ActorPelicula 
			//	//	}).Join(
			//	//	contextDos.Actor, 
			//	//	z => z.ActorPelicula.ActorId, 
			//	//	w => w.Id, 
			//	//	(ActorPelicula, Actor) => new { 
			//	//		ActorPelicula, 
			//	//		Actor 
			//	//	}).ToList();

			//}

			//GroupJoin

			using (var contextDos = new ApplicationDbContextFirst())
			{
                var actorPelicula = contextDos.ActorPelicula.Select(x => new {x.ActorId, x.PeliculaId}).GroupBy(x => x.ActorId).ToList();
                //var actorConSusPeliculas = from b in contextDos.Set<Actor>()
                //                           join p in contextDos.Set<ActorPelicula>()
                //                               on b.Id equals p.ActorId into grouping
                //                           select new { b, grouping };
                //actorConSusPeliculas.ToList();
            }
			Console.ReadLine();
		}
	}
}
