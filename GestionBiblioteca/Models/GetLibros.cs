using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Models
{
    public class GetLibros
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
    }
}
