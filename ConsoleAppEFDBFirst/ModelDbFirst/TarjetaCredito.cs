using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEFDBFirst.ModelDbFirst
{
    public partial class TarjetaCredito
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string CodigoTarjeta { get; set; }
        [StringLength(16)]
        public string Nrotarjeta { get; set; }
        public int ActorId { get; set; }
    }
}
