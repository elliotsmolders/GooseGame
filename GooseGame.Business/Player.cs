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

        public int CurrentPosition { get; set; }
        public int PreviousPosition { get; set; }
        private bool IsNpc { get; set; }
        public int NumberOfRolls { get; set; }
        public int CurrentRoll { get; set; }

        public bool IsInWell // hoort in methode bij Run - currently = redundant data
        { get; set; }

        public int Skips { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void UpdatePosition(int? setPosition = null) //splitsen naar twee methodes
        {
            if (setPosition == null)
            {
                if (CurrentPosition + CurrentRoll > GameBoard.GetGameBoard().AmountOfTiles - 1)
                {
                    CurrentPosition = MoveBackWards();
                }
                else
                {
                    PreviousPosition = CurrentPosition;
                    CurrentPosition += CurrentRoll;
                }
            }
            else
            {
                CurrentPosition = (int)setPosition;
            }
        }

        private int MoveBackWards()
        {
            return (GameBoard.GetGameBoard().AmountOfTiles - 1) + ((GameBoard.GetGameBoard().AmountOfTiles - 1) - (CurrentPosition + CurrentRoll));
        }

        public bool IsPlayerActive()
        {
            if (IsInWell)
            {
                return false;
            }
            if (Skips > 0)
            {
                Skips--;
                return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}