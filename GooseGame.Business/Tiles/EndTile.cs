using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    internal class EndTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            Console.WriteLine("U bent gewonnen");
        }
    }
}