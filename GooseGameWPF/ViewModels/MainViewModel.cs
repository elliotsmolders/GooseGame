using GooseGame.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GooseGameWPF.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private GameEngine _engine;
        public int ClickedRoll { get; set; }

        public MainViewModel()
        {
            _engine = new GameEngine();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public int RollDice()
        {
        return _engine.RollDice();
        }

        public void SetNextPlayer()
        {
            if (_engine.Winner == null) //moet verhuizen
            {
                _engine.SetNextPlayer();
            }
        }

        public void Init()
        {
            _engine.Init();
        }

        public string GetCurrentPlayerPositionAndName()
        {
            return $"{_engine.CurrentPlayer.Name} pos:{_engine.CurrentPlayer.CurrentPosition} coming from {_engine.CurrentPlayer.PreviousPosition}";
        }

        public int GetPlayerPosition()
        {
         return _engine.CurrentPlayer.CurrentPosition;
        }
        public void PlayTurn(int roll1,int roll2)
        {
            ClickedRoll++;
            //if (ClickedRoll == 1)
            //{
            //    _engine.HandleFirstThrow(roll1, roll2);
            //}
            _engine.PlayTurn(roll1,roll2);
        }



     
    }


}