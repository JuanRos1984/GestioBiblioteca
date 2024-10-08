using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;

namespace GestionBiblioteca.Services
{
    public class CategoriaServices
    {
        IRepository<Categoria> _repository;
        public CategoriaServices(IRepository<Categoria> _repository)
        {
            this._repository = _repository;
        }

        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            return await _repository.CreateAsync(categoria);
        }

        public async Task<bool> Update(Categoria categoria)
        {
            return await _repository.UpdateAsync(categoria);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
