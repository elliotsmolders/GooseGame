using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class PrisonTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public PrisonTile(int tileId) : base(tileId)
        {
            Name = "Prison";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Prison.png";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
            player.Skips = 3;
        }
    }
}