using GooseGame.DAL.Models;
using GooseGame.Services;
using GooseGame.Services.Interfaces;

namespace GooseGame.DBTESTING.Controllers
{
    public class GameController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task CreateAsync(Game game)
        {
            await _gameService.AddAsync(game);
        }

        public void Read(Game game)
        {
        }

        public void ReadAll()
        {
        }

        public void Update(Game game)
        {
        }

        public void Delete(Game game)
        {
        }
    }
}