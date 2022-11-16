using GooseGame.Business.Interfaces;
using System.ComponentModel;

namespace GooseGame.Business
{
    public class Player : INotifyPropertyChanged
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        private int currentPosition;

        public int CurrentPosition
        {
            get { return currentPosition; }
            set
            {
                currentPosition = value;
                CurrentTile.HandlePlayer(this);
            }
        }

        public int PreviousPosition { get; set; }
        private bool IsNpc { get; set; }
        public int NumberOfRolls { get; set; }
        public int CurrentRoll { get; set; }

        public ITile CurrentTile
        {
            get
            {
                return GameBoard.GetGameBoard().Tiles[CurrentPosition];
            }
        }

        public bool IsInWell // hoort in methode bij Run - currently = redundant data
        { get; set; }

        public int Skips { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void MovePlayer() //splitsen naar twee methodes
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

        public void SetPlayerPosition(int tileNumber)
        {
            CurrentPosition = tileNumber;
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