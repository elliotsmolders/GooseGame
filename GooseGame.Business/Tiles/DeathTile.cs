using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class DeathTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public DeathTile(int tileId) : base(tileId)
        {
            Name = "Death";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Death.png";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
            player.SetPlayerPosition(0);
        }
    }
}