using GooseGame.DAL;
using GooseGame.DAL.Models;
using GooseGame.DAL.Repositories;
using GooseGame.DBTESTING.Controllers;
using GooseGame.Services;
using GooseGame.Services.Interfaces;

internal class Program
{
    public static void Main(string[] args)
    {
        //add accesors after porting e.g. public / private
        BaseRepository<Player> playerRepo = new BaseRepository<Player>();
        BaseRepository<Game> gameRepo = new BaseRepository<Game>();
        IPlayerService playerService = new PlayerService(playerRepo);
        IGameService gameService = new GameService(gameRepo);

        GameController gameController = new GameController(gameService);
        PlayerController playerController = new PlayerController(playerService);
    }
}