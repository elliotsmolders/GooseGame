using GooseGame.Business.Interfaces;
using GooseGame.DAL.Models;

namespace GooseGame.Business.Tiles
{
    public class MazeTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.SetPlayerPosition(39);
            Console.WriteLine("Maze");
        }
    }
}