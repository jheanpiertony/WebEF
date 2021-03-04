using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppEFDBFirst.ModelDbFirst
{
    public partial class Pelicula
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaEstreno { get; set; }
        public bool EstaCartelera { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioTicket { get; set; }
    }
}
