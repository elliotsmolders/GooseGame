using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public class Player : INotifyPropertyChanged
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        public int CurrentPosition { get; set; } // default is al 0
        private bool IsNpc { get; set; } // default is al false
        public int NumberOfThrows { get; set; }
        public int CurrentRoll { get; set; }

        public bool IsInWell // hoort in methode bij Run - currently = redundant data
        { get; set; }

        public int Skips { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}