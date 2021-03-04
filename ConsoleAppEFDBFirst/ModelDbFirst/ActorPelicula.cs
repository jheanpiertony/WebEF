using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEFDBFirst.ModelDbFirst
{
    public partial class ActorPelicula
    {
        [Key]
        public int ActorId { get; set; }
        [Key]
        public int PeliculaId { get; set; }
    }
}
