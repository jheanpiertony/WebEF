using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEF.Models;

namespace WebEF.Dtos
{
    public class DireccionDto : Direccion
    {
        public string Longitud { get; set; }
        public string Latitud { get; set; }
    }
}
