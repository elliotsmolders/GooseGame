using GooseGame.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public class Player : INotifyPropertyChanged
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        public GameBoard Board { get; }
        public int CurrentPosition { get; set; }
        public int PreviousPosition { get; set; }
        private bool IsNpc { get; set; }
        public int NumberOfRolls { get; set; }
        public int CurrentRoll { get; set; }

        public bool IsInWell // hoort in methode bij Run - currently = redundant data
        { get; set; }

        public int Skips { get; set; }

        public Player(string name, GameBoard board)
        {
            Name = name;
            Board = board;
        }

        public void UpdatePosition(int? setPosition = null)
        {
            if (setPosition == null)
            {
                if (CurrentPosition + CurrentRoll > Board.AmountOfTiles - 1)
                {
                    CurrentPosition = (Board.AmountOfTiles - 1) + ((Board.AmountOfTiles - 1) - (CurrentPosition + CurrentRoll));
                }
                else
                {
                    CurrentPosition += CurrentRoll;
                }
            }
            else
            {
                CurrentPosition = (int)setPosition;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}