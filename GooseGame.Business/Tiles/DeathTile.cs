using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    public class DeathTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.SetPlayerPosition(0);
            Console.WriteLine("Death");
        }
    }
}