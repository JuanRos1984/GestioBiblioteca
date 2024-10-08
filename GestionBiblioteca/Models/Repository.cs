using GestionBiblioteca.Context;
using GestionBiblioteca.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionBiblioteca.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly BibliotecaContext context;
        readonly DbSet<T> dbSet;
        public Repository(BibliotecaContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            if (entity != null)
            {
                var registro = entity as Autor;
                registro.Activo = false;
                context.Entry(registro).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            else
                return false;
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            dbSet.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
