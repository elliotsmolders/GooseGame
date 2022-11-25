using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class BridgeTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public BridgeTile(int tileId) : base(tileId)
        {
            Name = "Bridge";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Bridge.png";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public override void HandlePlayer(Player player)
        {
            //TODO dit moet voor alle tiles gebeuren
            base.HandlePlayer(player);
            player.SetPlayerPosition(12);
        }
    }
}