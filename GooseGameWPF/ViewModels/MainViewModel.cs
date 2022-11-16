using GooseGame.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGameWPF.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private GameBoard _board;
        private GameEngine _engine;
        public int ClickedRoll { get; set; }

        public MainViewModel()
        {
            _board = new GameBoard();
            _engine = new GameEngine(_board);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public int RollDice()
        {
            return _engine.RollDice();
        }

        public void GetNextPlayer()
        {
            if (_engine.Winner != null)
            {
                return;
            }
            _engine.GetNextPlayer();
        }

        public void Init()
        {
            _engine.Init();
        }

        public string GetCurrentPlayerPositionAndName()
        {
            return $"{_engine.CurrentPlayer.Name} pos:{_engine.CurrentPlayer.CurrentPosition} coming from {_engine.CurrentPlayer.PreviousPosition}";
        }

        public void PlayTurn(int currentRoll)
        {
            ClickedRoll++;
            //if (ClickedRoll == 1)
            //{
            //    _engine.HandleFirstThrow(roll1, roll2);
            //}
            _engine.PlayTurn(currentRoll);
        }
    }
}