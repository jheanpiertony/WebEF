using WebEF.Models.Enums;
using WebEF.Validaciones;
using Microsoft.AspNetCore.Http;

namespace WebEF.Dtos
{
    public class ActorCreacionDto : ActorPatchDto
    {
        [PesoArchivoValidacionAttribute(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacionAttribute(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}
