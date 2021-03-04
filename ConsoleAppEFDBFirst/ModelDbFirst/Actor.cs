using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEFDBFirst.ModelDbFirst
{
    public partial class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Genero { get; set; }
        [Required]
        public bool? EstaBorrado { get; set; }
    }
}
