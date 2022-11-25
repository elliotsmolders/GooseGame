using GooseGame.Business.Interfaces;
using System.ComponentModel;
using GooseGame.Business.Tiles;
using GooseGame.Common;
using GooseGame.DAL.Entities;

namespace GooseGame.Business
{
    public class Player : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
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

        public GameEntity Game { get; set; } = new GameEntity();

        public int PreviousPosition { get; set; }
        private bool IsNpc { get; set; }
        public int NumberOfRolls { get; set; }
        public int CurrentRoll { get; set; }
        public int Sequence { get; set; }
        public int PlayerIcon { get; set; }

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

        public Player(string name, int playerId = 0, int playerIcon = 1)
        {
            Name = name;
            PlayerId = playerId;
            PlayerIcon = playerIcon;
        }

        public bool IsMovingBackwards { get; set; } = false;

        /// <summary>
        ///
        /// </summary>
        /// <param name="roll"></param>
        public void MovePlayer(int roll) //splitsen naar twee methodes
        {
            CurrentRoll = roll;

            if (CurrentPosition + roll > GameBoard.GetGameBoard().AmountOfTiles - 1)
            {
                IsMovingBackwards = true;
                CurrentPosition = MoveBackWards();
            }
            else
            {
                PreviousPosition = CurrentPosition;
                CurrentPosition += roll;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tileNumber"></param>
        public void SetPlayerPosition(int tileNumber)
        {
            CurrentPosition = tileNumber;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private int MoveBackWards()
        {
            return (GameBoard.GetGameBoard().AmountOfTiles - 1) + ((GameBoard.GetGameBoard().AmountOfTiles - 1) - (CurrentPosition + CurrentRoll));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool IsPlayerActive(int count)
        {
            if (IsInWell && count > 1)
            {
                Logger.AddToCurrentTurnLog($"{Name} is in well, turn is skipped");
                return false;
            }
            if (Skips > 0)
            {
                Logger.AddToCurrentTurnLog($"{Name} is stuck for another {Skips - 1} turns, turn is skipped");
                Skips--;
                return false;
            }
            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool isOnStartTile()
        {
            return CurrentTile.GetType() == typeof(StartTile);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}