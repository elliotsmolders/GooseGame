using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;
using GooseGame.DAL.Models;

namespace GooseGame.Business.Tiles
{
    public class InnTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.TurnsToSkip = 1;
            Console.WriteLine("Inn");
        }
    }
}