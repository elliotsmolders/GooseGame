using GooseGame.Business.Interfaces;
using GooseGame.DAL.Models;

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