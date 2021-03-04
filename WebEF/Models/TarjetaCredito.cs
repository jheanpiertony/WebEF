using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEF.Models
{
    public class TarjetaCredito
    {
        public int Id { get; set; }
        public string CodigoTarjeta { get; set; }
        public string Nrotarjeta { get; set; }
        //[NotMapped]
        public string ConfirmacionNrotarjeta { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
