using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebEF.Data;
using WebEF.Dtos;
using WebEF.Models;
using WebEF.Servicios;

namespace WebEF.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "peliculas";// La carpeta donde se guarda la foto de actores
        public PeliculasController(ApplicationDbContext _context,
            IAlmacenadorArchivos _almacenadorArchivo,
            IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
            almacenadorArchivos = _almacenadorArchivo;
        }
        // GET: PeliculasController
        public async Task<IActionResult> Index()
        {
            var listado = await context.Peliculas.ToListAsync();
            return View(listado);
        }
        // GET: PeliculasController
        public async Task<IActionResult> IndexPeliculasActores()
        {
            var peliculasActores = await context.Peliculas
                .Include(ap => ap.ActoresPeliculas)
                .ThenInclude(a => a.Actor)
                .ThenInclude(x => x.Direcciones)
                .ToListAsync();

            var a = context.Peliculas.Where(x => x.EstaCartelera == false && x.FechaEstreno <= DateTime.Now)
                .Select(x => new { x.Nombre, x.PrecioTicket })
                .ToList();
            return View(peliculasActores);
        }

        // GET: PeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PeliculasController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            var dto = mapper.Map<PeliculaEdicionDto>(pelicula);
            return View(dto);
        }

        // POST: PeliculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PeliculaEdicionDto peliculaEdicionDto)
        {
            var actor = mapper.Map<Pelicula>(peliculaEdicionDto);
            if (id != peliculaEdicionDto.Id)
            {
                return NotFound();
            }

            if (peliculaEdicionDto.FotoFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await peliculaEdicionDto.FotoFile.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(peliculaEdicionDto.FotoFile.FileName);
                    actor.UrlFoto = await almacenadorArchivos.GuardarArchivo(contenido, extension, contenedor,
                        peliculaEdicionDto.FotoFile.ContentType);
                }
            }
            else
            {
                actor.UrlFoto = peliculaEdicionDto.UrlFoto;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(actor);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(actor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(peliculaEdicionDto);
        }

        // GET: PeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeliculasController/Delete/5
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

        private bool PeliculaExists(int id)
        {
            return context.Actores.Any(e => e.Id == id);
        }
    }
}
