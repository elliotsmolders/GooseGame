using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class DeathTile : Tile, ITile
    {
        public DeathTile(int tileId) : base(tileId)
        {

        }
        public void HandlePlayer(Player player)
        {

            player.SetPlayerPosition(0);
        }
    }
}