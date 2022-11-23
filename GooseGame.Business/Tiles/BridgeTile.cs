using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class BridgeTile : Tile, ITile
    {
        public BridgeTile(int tileId) : base(tileId)
        {
            
            Name = "Bridge";
            BackgroundImage = " ";
        }
        public override void HandlePlayer(Player player)
        {
            //TODO dit moet voor alle tiles gebeuren
            base.HandlePlayer(player);
            player.SetPlayerPosition(12);
        }
    }
}