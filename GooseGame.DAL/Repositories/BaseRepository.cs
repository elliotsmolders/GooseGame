using GooseGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GooseGame.DAL.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public BaseRepository()
        {
        }

        public async Task SaveGameAsync()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T entity, GooseGameDbContext ctx)
        {
            ctx.Add(entity);
            //await ctx.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T?> GetAsync(int id, GooseGameDbContext ctx)
        {
            return await ctx.Set<T>().FindAsync(id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(T entity, GooseGameDbContext ctx)
        {
            ctx.Update(entity);
            //await ctx.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id, GooseGameDbContext ctx)
        {
            ctx.Remove(id);
            //await ctx.SaveChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> GetAllPlayersFromGameAsync(GooseGameDbContext ctx)
        {
            return await ctx.Set<T>().ToListAsync();
        }
    }
}