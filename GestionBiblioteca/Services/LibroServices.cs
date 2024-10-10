using GestionBiblioteca.Context;
using GestionBiblioteca.DTO;
using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GestionBiblioteca.Services
{
    public class LibroServices : ILibro
    {
        BibliotecaContext context;
        public LibroServices(BibliotecaContext context)
        {
            this.context = context;
        }
        public async Task<Response> Create(SetLibroDTO modelo)
        {
            var result = new Response();
            var transaction = context.Database.BeginTransaction();
            var libroAutor = new Libro_Autor();
            var libroCategoria = new Libro_Categoria();


            try
            {
                var idLibro = new SqlParameter("@IdSolicitudAdmision", SqlDbType.Int) { Direction = ParameterDirection.Output };
                await context.Database.ExecuteSqlRawAsync("[dbo].[SetLibro] {0},{1},{2}", modelo.Libro.Titulo, modelo.Libro.Descripcion, modelo.Libro.FechaPublicacion);

                int idLibroCreado = (int)idLibro.Value;
                if (idLibroCreado > 0)
                {
                    foreach (var item in modelo.Autores)
                    {
                        libroAutor.IdLibro = idLibroCreado;
                        libroAutor.IdAutor = item.IdAutor;
                        libroAutor.Activo = item.Activo;
                    }
                    await SetLibroAutor(libroAutor);
                    foreach (var item in modelo.Categorias)
                    {
                        libroCategoria.IdLibro = idLibroCreado;
                        libroCategoria.IdCategoria = item.IdCategoria;
                        libroCategoria.Activo = item.Activo;
                    }
                    await SetLibroCategoria(libroCategoria);
                }
                transaction.Commit();

            }
            catch (Exception ex)
            {   
                result.Errors.Add(ex.Message);
                transaction.Rollback();
            }
            return result;
        }

        public async Task<Response<GetLibros>> GetAllLibros()
        {
            var result = new Response<GetLibros>();
            try
            {
                var libro = await context.GetLibros.FromSqlRaw("[dbo].[GetLibros]").ToListAsync();

                if (libro.Any())
                    result.DataList = libro;
                else
                {
                    result.Message = "No se encontraron registros";

                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public async Task<Response<GetLibros>> GetLibroFiltro(LibroFiltroDTO param)
        {
            var result = new Response<GetLibros>();
            try
            {
                var libro = await context.GetLibros.FromSqlRaw("[dbo].[GetLibros] {0},{1},{2},{3},{4}",
                    param.Titulo, param.FechaDesde, param.FechaHasta, param.IdCategoria, param.IdAutor).ToListAsync();

                if (libro.Any())
                    result.DataList = libro;
                else
                {
                    result.Message = "No se encontraron registros";
                    
                }
            }
            catch (Exception ex)
            {  
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public async Task SetLibroAutor(Libro_Autor modelo)
        {
            await context.Database.ExecuteSqlRawAsync("[dbo].[SetLibroAutor] {0},{1}",modelo.IdLibro, modelo.IdAutor);
        }

        public async Task SetLibroCategoria(Libro_Categoria modelo)
        {
            await context.Database.ExecuteSqlRawAsync("[dbo].[SetLibroCategoria] {0},{1}",modelo.IdLibro, modelo.IdCategoria);
        }

        public async Task<Response> Update(SetLibroDTO modelo)
        {
            var result = new Response();
            var transaction = context.Database.BeginTransaction();
            var libroAutor = new Libro_Autor();
            var libroCategoria = new Libro_Categoria();


            try
            {
                await context.Database.ExecuteSqlRawAsync("[dbo].[UpdateLibro] {0},{1},{2},{3},{4}", 1,modelo.Libro.Id,modelo.Libro.Titulo, modelo.Libro.Descripcion, modelo.Libro.FechaPublicacion);

                foreach (var item in modelo.Autores)
                {
                    libroAutor.IdLibro = modelo.Libro.Id;
                    libroAutor.IdAutor = item.IdAutor;
                }
                await SetLibroAutor(libroAutor);
                foreach (var item in modelo.Categorias)
                {
                    libroCategoria.IdLibro = modelo.Libro.Id;
                    libroCategoria.IdCategoria = item.IdCategoria;
                }
                await SetLibroCategoria(libroCategoria);
                
                transaction.Commit();

            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                transaction.Rollback();
            }
            return result;
        }
    }
}
