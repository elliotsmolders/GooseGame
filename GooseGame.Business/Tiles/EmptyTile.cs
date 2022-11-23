using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class EmptyTile : Tile, ITile
    {

        public EmptyTile(int tileId) : base(tileId)
        {
            Name = $"Tile {tileId}";
            //BackgroundImage = " ";
        }

        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
        }
    }
}