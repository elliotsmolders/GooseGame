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
        public int AmountOfPlayers { get; set; } = 3;
        public int AmountOfTiles { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Player> ListOfPlayers { get; set; } = new List<Player>();
        public int AmountOfThrows { get; set; }
        public GameBoard Board { get; set; }
        public Dice Dice { get; set; }
        public Player VictoriousPlayer { get; set; } = null!;

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
            if (CurrentPlayer == null)
            {
                return ListOfPlayers[0];
            }
            int index = ListOfPlayers.IndexOf(CurrentPlayer);
            return index >= ListOfPlayers.Count() - 1 ? ListOfPlayers[0] : ListOfPlayers[index + 1];
        }

        private void PlayTurn(Player player)
        {
            if (player.IsInWell)
            {
                return;
            }
            if (player.Skips > 0)
            {
                player.Skips -= 1;
                return;
            }

            int roll1 = Dice.RollDice();
            int roll2 = Dice.RollDice();
            player.CurrentRoll = roll2 + roll1;
            CurrentPlayer.NumberOfThrows += 1;

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
                Console.WriteLine(Board.listOfTiles[CurrentPlayer.CurrentPosition].GetType());
                Board.listOfTiles[CurrentPlayer.CurrentPosition].HandlePlayer(CurrentPlayer);
            } while (Board.listOfTiles[CurrentPlayer.CurrentPosition] is GooseTile);
            Console.WriteLine($"{CurrentPlayer.Name} on position {player.CurrentPosition} \n *********************");
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