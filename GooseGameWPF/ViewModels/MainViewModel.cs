using GooseGame.Business;
using GooseGame.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GooseGameWPF.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Player> players;

        private List<string> totalLog;
        private string turnLog;

        public List<string> TotalLog
        {
            get { return totalLog; }
            set
            {
                totalLog = value;
                NotifyPropertyChanged(nameof(totalLog));
            }
        }

        public string TurnLog
        {
            get { return turnLog; }
            set
            {
                turnLog = value;
                NotifyPropertyChanged(nameof(turnLog));
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        private GameEngine _engine;
        public int ClickedRoll { get; set; }

        // public List<Rectangle> playerRectangles = new();
        public MainViewModel()
        {
            _engine = new GameEngine();
            players = new ObservableCollection<Player>(_engine.Players);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public int RollDice()
        {
            return _engine.RollDice();
        }

        public void SetNextPlayer()
        {
            _engine.SetNextPlayer();
        }

        public void Init()
        {
            _engine.Init();
        }

        public string GetCurrentPlayerPositions()
        {
            return $"{_engine.CurrentPlayer.PreviousPosition} pos:{_engine.CurrentPlayer.CurrentPosition} coming from {_engine.CurrentPlayer.PreviousPosition}";
        }

        public string GetPlayerName(int num)
        {
            return _engine.Players[num].Name;
        }

        public bool CheckForWinner()
        {
            return _engine.Winner != null;
        }

        public int GetPlayerPosition(int num)
        {
            return _engine.Players[num].CurrentPosition;
        }

        public int GetCurrentPlayerPosition()
        {
            return _engine.CurrentPlayer.CurrentPosition;
        }

        public string GetCurrentPlayerName()
        {
            return _engine.CurrentPlayer.Name;
        }

        public void UpdateLogList()

        {
            TotalLog = Logger.TotalLog;
        }

        public void UpdateTurnLog()
        {
            TurnLog = Logger.TurnLog;
        }

        public string GetCurrentPlayerTile()
        {
            return _engine.CurrentPlayer.CurrentTile.ToString();
        }

        public void PlayTurn(int roll1, int roll2)
        {
            ClickedRoll++;
            //if (ClickedRoll == 1)
            //{
            //    _engine.HandleFirstThrow(roll1, roll2);
            //}
            _engine.PlayTurn(roll1, roll2);
        }

        public string GetWinnerName()
        {
            return _engine.Winner.Name;
        }

        internal void AddPlayer(string name, int icon = 1)
        {
            _engine.AddPlayerAsync(name, icon);
        }
    }
}