using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Email{ get; set; }
        public string Clave{ get; set; }
        public bool Activo{ get; set; }
    }
}
