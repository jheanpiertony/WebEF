using WebEF.Validaciones;
using System;
using System.ComponentModel.DataAnnotations;
using WebEF.Models.Enums;

namespace WebEF.Dtos
{
    public class ActorDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [ValidarFechaNacimiento]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Foto")]
        public string UrlFoto { get; set; }

        [Display(Name = "Foto")]
        public Genero Genero { get; set; }
        public bool EstaBorrado { get; set; }
    }
}
