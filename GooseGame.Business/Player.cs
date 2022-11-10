using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public class Player
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        public int CurrentPosition { get; set; }
        private bool IsNpc { get; set; } = false;
        private int NumberOfThrows { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}