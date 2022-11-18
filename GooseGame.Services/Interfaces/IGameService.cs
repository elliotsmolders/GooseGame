using GooseGame.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Services.Interfaces
{
    public interface IGameService
    {
        Task DeleteAsync(int id);

        Task<IEnumerable<Game>> GetGamesAsync();

        Task<Game?> GetGameAsync(int id);

        Task UpdateAsync(Game game);

        Task AddAsync(Game game);
    }
}