﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public static class Dice
    {
        private static Random rnd = new Random();

        /// <summary>
        /// rnd initialized with .next to avoid not getting true randomness
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RollDice()
        {
            return rnd.Next(1, 6);
        }
    }
}