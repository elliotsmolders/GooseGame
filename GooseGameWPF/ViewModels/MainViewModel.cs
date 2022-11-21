using GooseGame.Business;
using GooseGameWPF.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace GooseGameWPF.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Player> players;

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

        public PlayerModel GetPlayer(int player){

            Player p = _engine.Players[player];
            return new PlayerModel
            {
                Name = p.Name,
                PlayerIcon = p.PlayerIcon,
                CurrentPosition = p.CurrentPosition
            };
        }

        public void SetPlayerPosition(int id, int pos)
        {
            _engine.Players[id].CurrentPosition = pos;
        }
        
        public List<Player> GetPlayers() 
        {
            return _engine.Players;
        }

        //public void assignPlayerIcon()
        //{
        //    foreach (var player in players)
        //    {
        //        playerRectangles.Add(new Rectangle());
        //        playerRectangles.Last();
        //    }
        //}

        public int GetCurrentPlayerPosition()
        {
            return _engine.CurrentPlayer.CurrentPosition;
        }

        public int GetPlayerPosition(int id)
        {
            return _engine.Players[id].CurrentPosition;
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
    }
}