using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    internal class BridgeTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.CurrentPosition = 12;
            Console.WriteLine("Bridge");
        }
    }
}