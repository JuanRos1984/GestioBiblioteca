using GestionBiblioteca.DTO;
using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;
using GestionBiblioteca.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("Todos")]
        [Authorize(Roles = "Bibliotecario")]
        public async Task<IActionResult> Get()
        {
            var libros = await service.GetAllLibros();
            if (libros.DataList.Count > 0)
                return Ok(libros);
            else
                return NotFound();
        }

        [HttpGet("FiltroLibros")]
        public async Task<IActionResult> Get([FromQuery] LibroFiltroDTO param)
        {
            var libros = await service.GetLibroFiltro(param);
            if (libros.DataList.Count>0)
                return Ok(libros);
            else
                return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Bibliotecario")]
        public async Task<IActionResult> Create(SetLibroDTO libro)
        {
            var result = await service.Create(libro);
            if (result.Succeded)
                return Ok(result);
            else
                return UnprocessableEntity(new { mensaje = "Registro no insertado" });
        }

        [HttpPut]
        [Authorize(Roles = "Bibliotecario")]
        public async Task<IActionResult> Update(SetLibroDTO libro)
        {
            var result = await service.Update(libro);
            if (result.Succeded)
                return Ok(new { mensaje = "Registro actualizado exitosamente" });
            else
                return UnprocessableEntity(new { mensaje = "Registro no actualizado" });
        }
    }
}
