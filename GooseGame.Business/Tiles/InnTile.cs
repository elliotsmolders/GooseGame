using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class InnTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public InnTile(int tileId) : base(tileId)
        {
            Name = "Inn";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Inn.png";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
            player.Skips = 1;
        }
    }
}