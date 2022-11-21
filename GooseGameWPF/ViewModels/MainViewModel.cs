using GooseGame.Business;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        public string GetCurrentPlayerPositions()
        {
            return $"{_engine.CurrentPlayer.PreviousPosition} pos:{_engine.CurrentPlayer.CurrentPosition} coming from {_engine.CurrentPlayer.PreviousPosition}";
        }

        public string GetPlayerName(int num)
        {
            return _engine.Players[num].Name;
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
        public string GetCurrentPlayerTile() {
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
    }
}