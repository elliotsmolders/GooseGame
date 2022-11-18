using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    public class EndTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            Console.WriteLine("U bent gewonnen");
        }
    }
}