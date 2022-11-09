using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business.Tiles
{
    internal class BridgeTile : ITile
    {
        public void HandlePlayer()
        {
            Console.WriteLine("Betaal de tol");
        }
    }
}