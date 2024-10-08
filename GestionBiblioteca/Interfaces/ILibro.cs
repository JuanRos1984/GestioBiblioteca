﻿using GestionBiblioteca.DTO;
using GestionBiblioteca.Models;

namespace GestionBiblioteca.Interfaces
{
    public interface ILibro
    {
        Task<Response> Create(SetLibroDTO modelo);
        Task<Response> Update(SetLibroDTO modelo);
        Task<Response<GetLibros>> GetLibroFiltro(LibroFiltroDTO modelo);
        Task<Response<GetLibros>> GetAllLibros();
    }
}
