using GooseGame.Business.Factory;
using GooseGame.Business.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public class GameEngine
    {
        public int AmountOfPlayers { get; set; } = 1;
        public int AmountOfTiles { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Player> ListOfPlayers { get; set; } = new List<Player>();
        public int AmountOfThrows { get; set; }
        public GameBoard Board { get; set; }
        public Dice Dice { get; set; }

        public GameEngine(GameBoard board, Dice dice)
        {
            Board = board;
            Dice = dice;
        }

        public void Init()
        {
            for (int i = 0; i < AmountOfPlayers; i++)
            {
                string name = $"Harold {i}";
                CreatePlayer(name);
            }
            foreach (var player in ListOfPlayers)
            {
                Console.WriteLine(player.Name);
            }
        }

        public void Run()
        {
            Console.WriteLine(Dice.RollDice());
        }

        private void CreatePlayer(string name)
        {
            ListOfPlayers.Add(new Player(name));
        }

        public void Restore()
        {
            throw new NotImplementedException();
        }
    }
}