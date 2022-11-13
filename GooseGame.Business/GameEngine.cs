using GooseGame.Business.Factory;
using GooseGame.Business.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    /// <summary>
    /// GameEngine mag singleton worden zodat deze zonder Depandancy injection overal oproepbaar is.
    /// Nog een goede reden, bevat enkel logica en geen save states
    ///
    /// Dal rechtstreeks van business aanspreken mag zonder tussenlayer, Frtonend mag er nooit rechtstreeks aankunnen
    /// Wich brings u to the following, Game als entity moet nog ingeladen worden in de engine zodat we de juiste properties kunnen bijhouden of opvragen.
    ///
    /// </summary>
    public class GameEngine
    {
        public GameBoard GameBoard { get; set; }
        public int AmountOfTiles { get; set; }
        public Player CurrentPlayer { get; set; }
        // public List<Player> Players { get; set; } = new List<Player>(); // verhuisd naar Game instance

        // public int AmountOfThrows { get; set; } // redundant
        public GameBoard Board { get; set; }

        public Player VictoriousPlayer { get; set; } = null!;

        // public int AmountOfPlayers { get; set; } // redundant
        public GameEngine(GameBoard board)
        {
            Board = board;
        }

        /// <summary>
        ///
        /// </summary>
        public void Init() // er moet eerst gegooid worden om te weten wie begint
        {
            for (int i = 0; i < AmountOfPlayers; i++)
            {
                string name = $"Harold {i}";
                CreatePlayer(name);
                CurrentPlayer = Players[0]; // beter voor bij new game :)) en vorige was eigenlijk initialisatie die telkens overlopen werd.
            }
        }

        public void Run()
        {
            while (VictoriousPlayer == null)
            {
                CurrentPlayer = GetNextPlayer();
                Console.ReadLine();
                PlayTurn(CurrentPlayer);
            }
        }

        private Player GetNextPlayer()
        {
            int index = Players.IndexOf(CurrentPlayer);
            return index >= Players.Count() - 1 ? Players[0] : Players[index + 1];
        }

        private void PlayTurn(Player player)
        {
            if (player.IsInWell)
            {
                return;
            }
            if (player.Skips > 0)
            {
                player.Skips--; //beter
                return;
            }

            int roll1 = Dice.RollDice();
            int roll2 = Dice.RollDice();
            player.CurrentRoll = roll2 + roll1;
            CurrentPlayer.NumberOfThrows++;

            Console.WriteLine($"{roll1} + {roll2}");

            if (player.NumberOfThrows == 0)
            {
                if ((roll1 == 5 && roll2 == 4) || (roll1 == 4 && roll2 == 5))
                {
                    player.CurrentPosition = 53;
                }
                else if ((roll1 == 6 && roll2 == 3) || (roll1 == 3 && roll2 == 6))
                {
                    player.CurrentPosition = 26;
                }
                else
                {
                    player.CurrentPosition += player.CurrentRoll;
                }
            }
            else
            {
                player.CurrentPosition += player.CurrentRoll;
            }
            do
            {
                Console.WriteLine(Board.Tiles[CurrentPlayer.CurrentPosition].GetType());
                Board.Tiles[CurrentPlayer.CurrentPosition].HandlePlayer(CurrentPlayer);
            } while (Board.Tiles[CurrentPlayer.CurrentPosition] is GooseTile);
            Console.WriteLine($"{CurrentPlayer.Name} on position {player.CurrentPosition} \n *********************");
        }

        private void CreatePlayer(string name)
        {
            Players.Add(new Player(name));
        }

        public void Restore()
        {
            throw new NotImplementedException();
        }
    }
}