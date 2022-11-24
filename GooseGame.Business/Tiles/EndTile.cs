using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class EndTile : Tile, ITile
    {
        public EndTile(int tileId) : base(tileId)
        {
            //moet nog een icoon hebben
            Name = "Winning Tile";
            //BackgroundImage = " ";
        }
        public void HandlePlayer(Player player)
        {

        }
    }
}