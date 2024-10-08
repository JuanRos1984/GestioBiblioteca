using GestionBiblioteca.DTO;
using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public bool Activo { get; set; }

        

    }
}
