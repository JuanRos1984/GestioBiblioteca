using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.DTO
{
    public class GetUsuarioDTO
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }

    }
}
