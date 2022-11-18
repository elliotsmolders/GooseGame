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
        IPlayerService playerService = new PlayerService();
        IGameService gameService = new GameService();

        GameController gameController = new GameController(gameService);
        PlayerController playerController = new PlayerController(playerService);
    }
}