using GooseGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GooseGame.DAL.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private GooseGameDbContext _ctx;

        public async Task AddAsync(T entity)
        {
            _ctx.Add(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _ctx.Update(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Remove(id);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }
    }
}