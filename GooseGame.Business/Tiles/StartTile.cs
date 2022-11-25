using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class StartTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public StartTile(int tileId) : base(tileId)
        {
            BackgroundImage = "pack://application:,,,/Resources/Icons/Start.png";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
        }
    }
}