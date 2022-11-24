using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class PrisonTile : Tile, ITile
    {
        public PrisonTile(int tileId) : base(tileId)
        {
            Name = "Prison";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Goose.png";
        }
        public void HandlePlayer(Player player)
        {

            player.Skips = 3;
            Console.WriteLine("Prison");
        }
    }
}