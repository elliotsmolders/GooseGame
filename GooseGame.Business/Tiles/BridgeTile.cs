using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
   public class BridgeTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.SetPlayerPosition(12);
            Console.WriteLine("Bridge");
        }
    }
}