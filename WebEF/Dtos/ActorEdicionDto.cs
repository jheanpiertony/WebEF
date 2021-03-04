using WebEF.Models.Enums;
using WebEF.Validaciones;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebEF.Dtos
{
    public class ActorEdicionDto : ActorDto
    {
        [PesoArchivoValidacionAttribute(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacionAttribute(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        [Display(Name = "Foto")]
        public IFormFile FotoFile { get; set; }
    }
}
