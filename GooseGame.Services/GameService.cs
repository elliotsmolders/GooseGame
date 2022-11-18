using GooseGame.DAL.Models;
using GooseGame.DAL.Repositories;
using GooseGame.Services.Interfaces;
using System.Collections.Generic;

namespace GooseGame.Services
{
    public class GameService : IGameService
    {
        private readonly BaseRepository<Game> _repo;

        public GameService()
        {
            _repo = new BaseRepository<Game>();
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task GetGameAsync(int id)
        {
            await _repo.GetAsync(id);
        }

        public Task<IEnumerable<Game>> GetGamesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Game game)
        {
            await _repo.AddAsync(game);
        }

        public async Task UpdateAsync(int id, Game game)
        {
            throw new NotImplementedException();
        }
    }
}