using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class MazeTile : Tile, ITile
    {
        public MazeTile(int tileId) : base(tileId)
        {

        }
        public void HandlePlayer(Player player)
        {
           
            player.SetPlayerPosition(39);
        }
    }
}