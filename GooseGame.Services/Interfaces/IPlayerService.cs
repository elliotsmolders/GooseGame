using GooseGame.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Services.Interfaces
{
    public interface IPlayerService
    {
        Task DeleteAsync(int id);

        Task<IEnumerable<Player>> GetPlayersAsync();

        Task<Player?> GetPlayerAsync(int id);

        Task UpdateAsync(Player player);

        Task AddAsync(Player player);
    }
}