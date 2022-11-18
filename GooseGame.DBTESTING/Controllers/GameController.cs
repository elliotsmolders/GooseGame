using GooseGame.DAL.Models;
using GooseGame.Services;
using GooseGame.Services.Interfaces;

namespace GooseGame.DBTESTING.Controllers
{
    public class GameController
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void Create(Game game)
        {
            gameService.Insert(game);
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