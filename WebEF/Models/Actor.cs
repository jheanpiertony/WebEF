using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebEF.Models.Enums;

namespace WebEF.Models
{
    public class Actor
    {
        public Actor()
        {
            EstaBorrado = false;
        }
        private string nombres;
        private string apellidos;
        public int Id { get; set; }        
        
        [JsonProperty("Nombres")]
        public string Nombres //Mapeo flexible x.Substring(1).ToLower()
        {
            get { return nombres; }
            set 
            {
                nombres = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x[1..].ToLower()).ToArray()); 
            }
        } 
        public string Apellidos
        {
            get { return apellidos; }
            set 
            { 
                apellidos = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x[1..].ToLower()).ToArray());
            }
        }
        public string UrlFoto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Genero Genero { get; set; }
        public bool EstaBorrado { get; set; }
        public List<ActorPelicula> ActoresPeliculas { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public TarjetaCredito TarjetaCredito { get; set; }
    }
}
