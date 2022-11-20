using GooseGame.Business;
using GooseGame.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GooseGameWPF.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Player> SelectablePlayers { get; set; }
        public ObservableCollection<Game> SelectableGames { get; set; }
        public ObservableCollection<Player> SelectedPlayers { get; set; }

        private readonly GameEngine _engine;

        public MainViewModel()
        {
            _engine = new GameEngine();
            RetrievePlayersAsync();
            RetrieveGames();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        public async Task RetrievePlayersAsync()
        {
            SelectablePlayers = await _engine.RetrievePlayers();
        }

        public async Task RetrieveGames()
        {
            SelectableGames = await _engine.RetrieveGames();
        }

        public void SelectPlayers()
        {
            //met UI element (listview ofzo denk ik) de selected players aanduiden
            //ik wens ook 1 default player aan te maken, als het spel start zonder selectie
            //beginnen we gewoon met 1 speler en schakelen we de well uit => new well as default?
        }

        public void AddPlayerAsync(string Playername)
        {
            _engine.AddPlayerAsync(Playername);
        }

        public void InstantiatePlayers()
        {
            _engine.InstantiatePlayers(SelectedPlayers);
        }

        public async Task InstantiateGameAsync()
        {
            await _engine.InstantiateGameAsync();
        }

        public Tuple<int, int> RollDice()
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

        /// <summary>
        /// Hier moeten de opties meegegeven worden : New Game -> Load Game en zoja welk spel
        /// </summary>
        public void Init()
        {
            _engine.Init();
        }

        public void PlayTurn()
        {
            _engine.PlayTurn();
        }
    }
}