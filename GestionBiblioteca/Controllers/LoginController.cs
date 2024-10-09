using GestionBiblioteca.DTO;
using GestionBiblioteca.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILogin login;
        public LoginController(ILogin login)
        {
            this.login = login;
        }
        [HttpPost("Acceder")]
        public IActionResult PostVerificar(LoginDTO model)
        {
            var result = login.Login(model);
            return Ok(result);

        }
    }
}
