using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class EmptyTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public EmptyTile(int tileId) : base(tileId)
        {
            Name = $"Tile {tileId}";
            //BackgroundImage = " ";
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