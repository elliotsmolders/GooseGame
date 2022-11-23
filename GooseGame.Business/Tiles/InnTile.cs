using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class InnTile : Tile, ITile
    {
        public InnTile(int tileId) : base(tileId)
        {
            Name = "Inn";
            //BackgroundImage = " ";
        }
        public void HandlePlayer(Player player)
        {

            player.Skips = 1;
        }
    }
}