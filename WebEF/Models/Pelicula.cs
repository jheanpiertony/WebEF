using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEF.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaEstreno { get; set; }
        public bool EstaCartelera { get; set; }
        public decimal PrecioTicket { get; set; }

        public List<ActorPelicula> ActoresPeliculas { get; set; }
    }
}
