using GooseGame.DAL.Models;
using GooseGame.DAL.Repositories;
using GooseGame.Services.Interfaces;
using System.Collections.Generic;

namespace GooseGame.Services
{
    public class PlayerService : IPlayerService
    {
        private BaseRepository<Player> _repo;

        public PlayerService()
        {
            _repo = new BaseRepository<Player>();
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<Player?> GetPlayerAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task InsertAsync(Player player)
        {
            await _repo.AddAsync(player);
        }

        public async Task UpdateAsync(int id, Player player)
        {
            await _repo.UpdateAsync(id, player);
        }
    }
}