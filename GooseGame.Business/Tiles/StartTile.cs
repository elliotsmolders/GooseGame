using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class StartTile : Tile, ITile
    {
        public StartTile(int tileId) : base(tileId)
        {
            BackgroundImage = "pack://application:,,,/Resources/Icons/Start.png";
        }

        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
        }
    }
}