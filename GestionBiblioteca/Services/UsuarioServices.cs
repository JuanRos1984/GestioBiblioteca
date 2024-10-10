using GestionBiblioteca.DTO;
using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;
using GestionBiblioteca.Utils;

namespace GestionBiblioteca.Services
{
    public class UsuarioServices
    {
        readonly IRepository<Usuario> _repository;
        readonly EncryptionHelper encryptionHelper;

        public UsuarioServices(IRepository<Usuario> _repository, EncryptionHelper encryptionHelper)
        {
            this._repository = _repository;
            this.encryptionHelper = encryptionHelper;
        }
        public async Task<IEnumerable<Usuario>> Get()
        {
            var usuarios = await _repository.GetAllAsync();

            var result = usuarios.Select(a => new Usuario
            {
                Id = a.Id,
                Email = a.Email,
                Clave = string.Empty,
                Activo = a.Activo,
                IdRol = a.IdRol
            }).ToList();
            return result;
        }

        public async Task<Usuario> GetById(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            usuario.Clave = string.Empty;
            return usuario;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            usuario.Clave = encryptionHelper.Encrypt(usuario.Clave);
            return await _repository.CreateAsync(usuario);
        }

        public async Task<bool> Update(Usuario usuario)
        {
            return await _repository.UpdateAsync(usuario);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
