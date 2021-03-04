using System;
using System.ComponentModel.DataAnnotations;

namespace WebEF.Dtos
{
    public class PeliculaDto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaEstreno { get; set; }
        public bool EstaCartelera { get; set; }
        public decimal PrecioTicket { get; set; }
    }
}
