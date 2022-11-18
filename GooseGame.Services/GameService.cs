using GooseGame.DAL.Models;
using GooseGame.DAL.Repositories;
using GooseGame.Services.Interfaces;
using System.Collections.Generic;

namespace GooseGame.Services
{
    public class GameService : IGameService
    {
        private readonly BaseRepository<Game> _repo;

        public GameService(BaseRepository<Game> gameRepo)
        {
            _repo = gameRepo;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<Game?> GetGameAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public Task<IEnumerable<Game>> GetGamesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Game game)
        {
            await _repo.AddAsync(game);
        }

        public async Task UpdateAsync(Game game)
        {
            throw new NotImplementedException();
        }
    }
}