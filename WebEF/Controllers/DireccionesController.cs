using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEF.Data;
using WebEF.Dtos;
using WebEF.Models;
using WebEF.Models.Enums;
using WebEF.Servicios;

namespace WebEF.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;

        public DireccionesController(ApplicationDbContext _context,
            IAlmacenadorArchivos _almacenadorArchivo,
            IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
            almacenadorArchivos = _almacenadorArchivo;
        }
        // GET: DireccionesController
        public ActionResult Index()
        {
            var a = context.Direcciones.ToList();
            return View(a);
        }

        // GET: DireccionesController
        public async Task<IActionResult> DireccionesActores()
        {
            var arnaldoUbicacion = context.Actores
                .Where(x => x.Nombres.Contains("Arnold Alois"))
                .Include(x => x.Direcciones).First()
                .Direcciones
                .FirstOrDefault(x => x.TipoDireccion == TipoDireccion.CasaCampo).Ubicacion;

            var actorDirecciones = await context.Direcciones
                .OrderBy(x => x.Ubicacion.Distance(arnaldoUbicacion))
                .Where(x => x.Ubicacion.IsWithinDistance(arnaldoUbicacion, 30000))
                .Select(x => new 
                { 
                    x.Actor.Nombres, 
                    x.Actor.Apellidos, 
                    x.Ubicacion, 
                    x.TipoDireccion, 
                    x.StringDireccion, 
                    Distancia = x.Ubicacion.Distance(arnaldoUbicacion) 
                }).ToListAsync();

            string markers = $"[";
            foreach (var item in actorDirecciones)
            {
                markers += "{";
                markers += string.Format("'title': '{0}',", $"{item.Nombres} {item.Apellidos} {item.TipoDireccion.ToString()}");
                markers += string.Format("'lat': '{0}',", item.Ubicacion.Y.ToString().Replace(",", "."));
                markers += string.Format("'lng': '{0}',", item.Ubicacion.X.ToString().Replace(",", "."));
                markers += string.Format("'description': '{0}'", $"{item.StringDireccion}, Dist: {item.Distancia.ToString("N0")} mtrs.");
                markers += "},";
            }
            markers += $"];";
            ViewBag.Markers = markers;

            #region revisar el JSon
            var actorDireccionesDos = await context.Direcciones
                   .Include(x => x.Actor)
                   .OrderBy(x => x.Ubicacion.Distance(arnaldoUbicacion))
                   .Where(x => x.Ubicacion.IsWithinDistance(arnaldoUbicacion, 15000)).ToListAsync(); var actoresDireccionesDtos = new List<ActoresDireccionesDto>();
            foreach (var item in actorDireccionesDos)
            {
                actoresDireccionesDtos.Add(new ActoresDireccionesDto()
                {
                    Description = item.StringDireccion,
                    Lat = item.Ubicacion.Y.ToString().Replace(",", "."),
                    Lng = item.Ubicacion.X.ToString().Replace(",", "."),
                    Title = $"{item.Actor.Nombres} {item.Actor.Apellidos} {item.TipoDireccion.ToString()}"
                });
            }
            string output = JsonConvert.SerializeObject(actoresDireccionesDtos); 
            #endregion

            return View(actorDireccionesDos);
        }

        // GET: DireccionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DireccionesController/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(context.Actores.OrderBy(x => x.Nombres).ToList(), "Id", "Nombres");
            return View();
        }

        // POST: DireccionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,StringDireccion,TipoDireccion,ActorId,Longitud,Latitud")] DireccionDto collection)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var _lat = collection.Latitud.Replace(".", ",");
            var _long = collection.Longitud.Replace(".", ",");
            var longitud = Convert.ToDouble(_long);
            var latitud = Convert.ToDouble(_lat);
            var direccion = new Direccion()
            {
                ActorId = collection.ActorId,
                StringDireccion = collection.StringDireccion,
                TipoDireccion = collection.TipoDireccion,
                Ubicacion = geometryFactory.CreatePoint(new Coordinate(longitud, latitud))
            };
            try
            {
                context.Add(direccion);
                context.SaveChanges();
                return RedirectToAction(nameof(DireccionesActores));
            }
            catch
            {
                ViewBag.ActorId = new SelectList(context.Actores.OrderBy(x => x.Nombres).ToList(), "Id", "Nombres");
                return View(collection);
            }
        }

        // GET: DireccionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DireccionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DireccionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DireccionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
