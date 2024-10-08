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
        readonly LibroServices service;
        public LibroController(LibroServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var autores = await service.Get();
            if (autores.Any())
                return Ok(autores);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var autor = await service.GetById(id);
            if (autor != null)
                return Ok(autor);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Libro libro)
        {
            var result = await service.Create(libro);
            if (result != null)
                return Ok(result);
            else
                return UnprocessableEntity(new { mensaje = "Registro no insertado" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Libro libro)
        {
            var result = await service.Update(libro);
            if (result)
                return Ok(new { mensaje = "Registro actualizado exitosamente" });
            else
                return UnprocessableEntity(new { mensaje = "Registro no actualizado" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            if (result)
                return Ok(new { mensaje = "Registro eliminado exitosamente" });
            else
                return NotFound(new { mensaje = "No se encuentra registro con este id" });
        }
    }
}
