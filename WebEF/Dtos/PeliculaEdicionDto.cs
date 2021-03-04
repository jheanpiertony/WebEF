using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebEF.Models.Enums;
using WebEF.Validaciones;

namespace WebEF.Dtos
{
    public class PeliculaEdicionDto : PeliculaDto
    {
        [PesoArchivoValidacionAttribute(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacionAttribute(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        [Display(Name = "Foto")]
        public IFormFile FotoFile { get; set; }
    }
}
