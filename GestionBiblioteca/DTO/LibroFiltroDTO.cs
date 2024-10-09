namespace GestionBiblioteca.DTO
{
    public class LibroFiltroDTO
    {
        public string? Titulo { get; set; } 
        public DateTime? FechaDesde { get; set; } 
        public DateTime? FechaHasta { get; set; } 
        public int? IdCategoria { get; set; } 
        public int? IdAutor { get; set; } 
    }
}
