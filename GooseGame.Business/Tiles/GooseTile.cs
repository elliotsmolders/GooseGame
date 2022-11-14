using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    internal class GooseTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.CurrentPosition += player.CurrentRoll;
            Console.WriteLine($"Goose by rolling {player.CurrentPosition}");
        }
    }
}