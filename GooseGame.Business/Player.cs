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

        public int CurrentPosition { get; set; } = 0;
        private bool IsNpc { get; set; } = false;
        private int NumberOfThrows { get; set; }
        public bool IsActive { get; set; }
        public int Skips { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}