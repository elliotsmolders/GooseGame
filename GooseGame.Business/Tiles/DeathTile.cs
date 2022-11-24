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

        //moet nog background hebben
        public DeathTile(int tileId) : base(tileId)
        {
            Name = "Death";
            BackgroundImage = "pack://application:,,,/Resources/Icons/Death.png";
        }
        public void HandlePlayer(Player player)
        {
            base.HandlePlayer(player);
            player.SetPlayerPosition(0);
        }
    }
}