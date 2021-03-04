using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebEF.Data;
using WebEF.Dtos;
using WebEF.Models;
using WebEF.Servicios;

namespace WebEF.Controllers
{
    public class ActoresController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "actores";// La carpeta donde se guarda la foto de actores

        public ActoresController(ApplicationDbContext _context,
            IAlmacenadorArchivos _almacenadorArchivo,
            IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
            almacenadorArchivos = _almacenadorArchivo;
        }

        // GET: Actores
        public async Task<IActionResult> Index()
        {
            var listado = await context.Actores.ToListAsync();
            return View(listado);
        }

        // GET: Actores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await context.Actores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorCreacionDto actorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDTO);

            if (actorCreacionDTO.Foto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await actorCreacionDTO.Foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(actorCreacionDTO.Foto.FileName);
                    entidad.UrlFoto = await almacenadorArchivos.GuardarArchivo(contenido, extension, contenedor,
                        actorCreacionDTO.Foto.ContentType);
                }
            }
            if (ModelState.IsValid)
            {
                context.Add(entidad);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actorCreacionDTO);
        }

        // GET: Actores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await context.Actores.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            var dto = mapper.Map<ActorEdicionDto>(actor);
            return View(dto);
        }

        // POST: Actores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ActorEdicionDto actorEdicionDto)
        {
            var actor = mapper.Map<Actor>(actorEdicionDto);
            if (id != actorEdicionDto.Id)
            {
                return NotFound();
            }

            if (actorEdicionDto.FotoFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await actorEdicionDto.FotoFile.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(actorEdicionDto.FotoFile.FileName);
                    actor.UrlFoto = await almacenadorArchivos.GuardarArchivo(contenido, extension, contenedor,
                        actorEdicionDto.FotoFile.ContentType);
                }
            }
            else
            {
                actor.UrlFoto = actorEdicionDto.UrlFoto;
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
                    if (!ActorExists(actor.Id))
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
            return View(actorEdicionDto);
        }

        // GET: Actores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await context.Actores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await context.Actores.FindAsync(id);
            context.Actores.Remove(actor);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return context.Actores.Any(e => e.Id == id);
        }
    }
}
