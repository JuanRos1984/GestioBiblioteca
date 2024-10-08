using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
