﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;
using GooseGame.DAL.Models;

namespace GooseGame.Business.Tiles
{
    public class DefaultTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            Console.WriteLine("Empty");
        }
    }
}