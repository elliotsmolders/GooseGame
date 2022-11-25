using GooseGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GooseGame.DAL.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public GooseGameDbContext _ctx;

        public BaseRepository()
        {
            _ctx = new GooseGameDbContext();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            _ctx.Add(entity);
            await _ctx.SaveChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> GetAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            _ctx.Update(entity);
            await _ctx.SaveChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            _ctx.Remove(id);
            await _ctx.SaveChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> GetAllPlayersFromGameAsync()
        {
            return await _ctx.Set<T>().ToListAsync(); //
        }
    }
}