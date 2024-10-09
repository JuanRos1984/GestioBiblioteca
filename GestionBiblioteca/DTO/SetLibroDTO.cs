using GestionBiblioteca.Models;

namespace GestionBiblioteca.DTO
{
    public class SetLibroDTO
    {
        public Libro Libro { get; set; }
        public List<SetLibroAutorDTO> Autores { get; set; }
        public List<SetLibroCategoriaDTO> Categorias { get; set; }
    }
}
