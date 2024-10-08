using GestionBiblioteca.Context;
using GestionBiblioteca.Interfaces;
using GestionBiblioteca.Models;

namespace GestionBiblioteca.Services
{
    public class AutorServices 
    {
       readonly IRepository<Autor> _repository;
        public AutorServices(IRepository<Autor> _repository)
        {
            this._repository = _repository;
        }

        public async Task<IEnumerable<Autor>> Get()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Autor> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        //public async Task Add(Autor autor)
        //{
        //    await _repository.CreateAsync(autor);
        //}

        //public async Task Update(Autor autor)
        //{ 
        //    await _repository.UpdateAsync(autor);
        //}

        public async Task<bool> Delete(int id)
        { 
           return await _repository.DeleteAsync(id);
        }
    }
}
