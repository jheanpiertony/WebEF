using NetTopologySuite.Geometries;
using WebEF.Models.Enums;

namespace WebEF.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string StringDireccion { get; set; }
        public TipoDireccion TipoDireccion { get; set; }
        public Point Ubicacion { get; set; }//Longitud y Latitud

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
