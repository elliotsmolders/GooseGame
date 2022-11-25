using GooseGame.Business;
using GooseGame.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GooseGameWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
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

        public void Init()
        {
            _engine.Init();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        private GameEngine _engine;

        public MainViewModel()
        {
            _engine = new GameEngine();
            players = new ObservableCollection<Player>(_engine.Players);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Tuple<int, int> RollDice()
        {
            return _engine.RollDice();
        }

        public void SetNextPlayer()
        {
            _engine.SetNextPlayer();
        }

        public string GetCurrentPlayerPositions()
        {
            return $"{_engine.CurrentPlayer.PreviousPosition} pos:{_engine.CurrentPlayer.CurrentPosition} coming from {_engine.CurrentPlayer.PreviousPosition}";
        }

        public int GetCurrentPlayerId()
        {
            return _engine.Players.IndexOf(_engine.CurrentPlayer);
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

        internal int GetPlayerPreviousPosition(int num)
        {
            return _engine.Players[num].PreviousPosition;
        }

        public int GetCurrentPlayerCurrentPosition()
        {
            return _engine.CurrentPlayer.CurrentPosition;
        }

        public int GetCurrentPlayerPreviousPosition()
        {
            return _engine.CurrentPlayer.PreviousPosition;
        }

        public string GetCurrentPlayerName()
        {
            return _engine.CurrentPlayer.Name;
        }

        public string GetPlayerCurrentTileName(int num)
        {
            return _engine.Players[num].CurrentTile.Name;
        }

        public string GetCurrentPlayerTileName()
        {
            return _engine.CurrentPlayer.CurrentTile.Name;
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
            return _engine.CurrentPlayer.CurrentTile.Name;
        }

        public int GetPlayerAmount()
        {
            return _engine.Players.Count;
        }

        public void PlayTurn()
        {
            _engine.PlayTurn();
        }

        public string GetWinnerName()
        {
            return _engine.Winner.Name;
        }

        internal void AddPlayer(string name, int icon = 1)
        {
            _engine.CreatePlayer(name, icon);
        }

        internal async Task WriteGameToDatabaseAsync()
        {
            await _engine.WriteGameToDatabaseAsync();
        }

        internal int CurrentSequence()
        {
            return _engine.CurrentPlayer.Sequence;
        }
    }
}