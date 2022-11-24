using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class PrisonTile : Tile, ITile
    {
        public PrisonTile(int tileId) : base(tileId)
        {
            Name = "Prison";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Prison.png";
        }
        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
            player.Skips = 3;
        }
    }
}