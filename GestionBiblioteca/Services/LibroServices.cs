using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;

namespace GestionBiblioteca.Services
{
    public class LibroServices
    {
        IRepository<Libro> _repository;
        public LibroServices(IRepository<Libro> _repository)
        {
            this._repository = _repository;
        }

        public async Task<IEnumerable<Libro>> Get()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Libro> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Libro> Create(Libro libro)
        {
            return await _repository.CreateAsync(libro);
        }

        public async Task<bool> Update(Libro libro)
        {
            return await _repository.UpdateAsync(libro);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
