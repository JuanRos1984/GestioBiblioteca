using GestionBiblioteca.DTO;

namespace GestionBiblioteca.Interfaces
{
    public interface ILogin
    {
        Task<Response<GetUsuarioDTO>> Login(LoginDTO login);
        
    }
}
