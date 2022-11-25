using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class MazeTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public MazeTile(int tileId) : base(tileId)
        {
            //moet nog een image krijgen
            Name = "Maze";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Maze.png";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
            player.SetPlayerPosition(39);
        }
    }
}