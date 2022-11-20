using GooseGame.Business.Interfaces;
using System.ComponentModel;
using GooseGame.Business.Tiles;

namespace GooseGame.Business
{
    public class Player
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        public int CurrentPosition { get; set; }

        public int PreviousPosition { get; set; }
        private bool IsNpc { get; set; }
        public int NumberOfRolls { get; set; }

        public ITile CurrentTile
        {
            get
            {
                return GameBoard.GetGameBoard().Tiles[CurrentPosition];
            }
        }

        public bool IsInWell // hoort in methode bij Run - currently = redundant data
        { get; set; }

        public int TurnsToSkip { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void MovePlayer(int roll) //splitsen naar twee methodes
        {
            PreviousPosition = CurrentPosition;

            CurrentPosition += roll;
            if (CurrentPosition > GameBoard.EndTilePosition)
            {
                var previousUntilEnd = GameBoard.EndTilePosition - PreviousPosition;
                var stepsLeftBackwards = roll - previousUntilEnd;
                CurrentPosition = GameBoard.EndTilePosition - stepsLeftBackwards;
            }

            CurrentTile.HandlePlayer(this); //TODO : move?!
        }

        public void SetPlayerPosition(int tileNumber)
        {
            CurrentPosition = tileNumber;

            CurrentTile.HandlePlayer(this); //TODO : move?!
        }

        public bool IsPlayerActive()
        {
            if (IsInWell)
            {
                return false;
            }
            if (TurnsToSkip > 0)
            {
                TurnsToSkip--;
                return false;
            }
            return true;
        }
    }
}