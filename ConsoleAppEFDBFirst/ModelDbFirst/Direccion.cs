using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEFDBFirst.ModelDbFirst
{
    public partial class Direccion
    {
        [Key]
        public int Id { get; set; }
        public string StringDireccion { get; set; }
        public int TipoDireccion { get; set; }
        public int ActorId { get; set; }
        public Point Ubicacion { get; set; }//Longitud y Latitud
    }
}
