﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business.Tiles
{
    internal class InnTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.CurrentPosition = 39;
        }
    }
}