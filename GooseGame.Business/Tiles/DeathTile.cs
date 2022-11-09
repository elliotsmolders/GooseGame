using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business.Tiles
{
    internal class DeathTile : Business.ITile
    {
        public void HandlePlayer()
        {
            Console.WriteLine("You are dead.");
        }
    }
}