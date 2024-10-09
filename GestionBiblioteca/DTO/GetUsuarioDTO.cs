using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.DTO
{
    public class GetUsuarioDTO
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
