using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    public class PrisonTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.Skips = 3;
            Console.WriteLine("Prison");
        }
    }
}