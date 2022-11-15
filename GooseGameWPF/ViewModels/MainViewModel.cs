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

        public MainViewModel()
        {
            _board = new GameBoard();
            _engine = new GameEngine(_board);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public IList<Dice> RollDice()
        {
            return _engine.Run();
        }
    }
}