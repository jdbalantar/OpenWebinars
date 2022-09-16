using CursoArquitecturaNet.Core.Entities.Base;
using CursoArquitecturaNet.Core.Repository.Base;
using CursoArquitecturaNet.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CursoArquitecturaNet.Infraestructure.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly CursoArquitecturaNetContext _dbContext;

        public Repository(CursoArquitecturaNetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAlLAsync() => await _dbContext.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) => await _dbContext.Set<T>().Where(predicate).ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
