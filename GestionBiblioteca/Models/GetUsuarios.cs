using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Models
{
    public class GetUsuarios
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
