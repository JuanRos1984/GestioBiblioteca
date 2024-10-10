using GestionBiblioteca.Context;
using GestionBiblioteca.DTO;
using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionBiblioteca.Services
{
    public class LoginService : ILogin
    {
        IConfiguration _configuration;
        BibliotecaContext context;
        readonly EncryptionHelper encryptionHelper;
        public LoginService(IConfiguration configuration, BibliotecaContext context, EncryptionHelper encryptionHelper)
        {
            _configuration = configuration;
            this.context = context;
            this.encryptionHelper = encryptionHelper;
        }
        public async Task<Response<GetUsuarioDTO>> Login(LoginDTO login)
        {
            var result = new Response<GetUsuarioDTO>();

            var usuario = context.GetUsuarios.FromSqlRaw("[dbo].[GetUsuarios] {0}",login.email).ToList().FirstOrDefault();

            if (usuario != null)
            {
                if (encryptionHelper.Decrypt(usuario.Clave) == login.clave)
                {
                    var usuarioRetorno = new GetUsuarioDTO
                    {
                        Email = usuario.Email,
                        Id = usuario.Id,
                        IdRol = usuario.IdRol,
                        Rol = usuario.Rol,  
                    };

                    result.SingleData = usuarioRetorno;
                    result.stringCode = GenerateJwtToken(login.email, usuario.IdRol,usuario.Rol);
                }
                else
                    result.Message = "Usuario y/o contraseña incorrectos";

            }
            else
            {
                result.Message = "Usuario no encontrado";
            }       
            return result;
        }

        private string GenerateJwtToken(string email, int idRol, string rol)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim("idRol", idRol.ToString()),
            new Claim(ClaimTypes.Role,rol),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["DurationInMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
