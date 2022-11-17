using GooseGame.Business.Interfaces;

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