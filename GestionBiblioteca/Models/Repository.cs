using GestionBiblioteca.Context;
using GestionBiblioteca.Interfaces;
using Microsoft.Data.SqlClient;
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
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al intentar esta operación",ex);
            }
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
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
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al intentar esta operación", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                dbSet.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al intentar esta operación", ex);
            }
            
        }
    }
}
