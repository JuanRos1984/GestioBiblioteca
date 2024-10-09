using GestionBiblioteca.Context;
using GestionBiblioteca.DTO;
using GestionBiblioteca.Interfaces;
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
        public LoginService(IConfiguration configuration, BibliotecaContext context)
        {
            _configuration = configuration;
            this.context = context;
        }
        public async Task<Response<GetUsuarioDTO>> Login(LoginDTO login)
        {
            var result = new Response<GetUsuarioDTO>();

            var usuarios = context.GetUsuarios.FromSqlRaw("[dbo].[GetUsuarios]").ToList();

            var user = usuarios.FirstOrDefault(a=>a.Email == login.email);


            if (user != null)
            {
                var usuarioRetorno = new GetUsuarioDTO
                {
                    Email = user.Email,
                    Id = user.Id,
                };

                result.SingleData = usuarioRetorno;
                result.stringCode = GenerateJwtToken(login.email);
            }
            else
                result.Message = "Usuario no encontrado";
            return result;
        }

        private string GenerateJwtToken(string email)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, email),
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
