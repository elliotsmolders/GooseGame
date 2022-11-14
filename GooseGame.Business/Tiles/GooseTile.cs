using GooseGame.Business;
using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    internal class GooseTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.UpdatePosition();
            Console.WriteLine($"Goose by rolling {player.CurrentRoll}");
        }
    }
}