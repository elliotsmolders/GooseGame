using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    internal class MazeTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.MovePlayer(39);
            Console.WriteLine("Maze");
        }
    }
}