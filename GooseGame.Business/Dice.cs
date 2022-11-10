using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public class Dice
    {
        private Random rnd = new Random();

        public int RollDice(int max = 6, int min = 1)
        {
            return rnd.Next(min, max);
        }
    }
}