using GestionBiblioteca.DTO;
using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;
using GestionBiblioteca.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        readonly ILibro service;
        public LibroController(ILibro service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(LibroFiltroDTO param)
        {
            var libros = await service.GetLibros(param);
            if (libros.DataList.Count>0)
                return Ok(libros);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SetLibroDTO libro)
        {
            var result = await service.Create(libro);
            if (result.Succeded)
                return Ok(result);
            else
                return UnprocessableEntity(new { mensaje = "Registro no insertado" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(SetLibroDTO libro)
        {
            var result = await service.Update(libro);
            if (result.Succeded)
                return Ok(new { mensaje = "Registro actualizado exitosamente" });
            else
                return UnprocessableEntity(new { mensaje = "Registro no actualizado" });
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await service.Delete(id);
        //    if (result)
        //        return Ok(new { mensaje = "Registro eliminado exitosamente" });
        //    else
        //        return NotFound(new { mensaje = "No se encuentra registro con este id" });
        //}
    }
}
