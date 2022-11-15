using GooseGame.Business.Tiles;
using GooseGame.DAL.Models;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

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
        public Player CurrentPlayer { get; set; }
        public List<Player> Players { get; set; } = new List<Player>(); // verhuisd naar Game instance

        public int TotalNumberOfRolls { get; set; }
        public GameBoard Board { get; set; }

        public Player Winner { get; set; } = null!;

        public int AmountOfPlayers { get; set; } = 4;
        public Dice Dice1 { get; set; } = new Dice();
        public Dice Dice2 { get; set; } = new Dice();
        public IList<Dice> Dices { get; set; }

        public GameEngine(GameBoard board)
        {
            Board = board;
        }

        public void Init()
        {
            for (int i = 0; i < AmountOfPlayers; i++)
            {
                string name = $"Harold {i}";
                CreatePlayer(name);
                CurrentPlayer = Players[0];
            }
        }

        public void Run()
        {
            CurrentPlayer = GetNextPlayer();
            PlayTurn(CurrentPlayer);
            if (CurrentPlayer.CurrentPosition == 63)
            {
                Winner = CurrentPlayer;
            }
        }

        private Player GetNextPlayer()
        {
            int index = Players.IndexOf(CurrentPlayer);
            return index >= Players.Count() - 1 ? Players[0] : Players[index + 1];
        }

        public void PlayTurn(Player player)
        {
            if (!IsPlayerActive(player))
            {
                return;
            }
            Dice1.RollDice();
            int roll1 = Dice1.Roll;
            Dice2.RollDice();
            int roll2 = Dice2.Roll;
            player.CurrentRoll = roll1 + roll2;

            Console.WriteLine($"{roll1} + {roll2}");
            if (player.NumberOfRolls == 0)
            {
                HandleFirstThrow(roll1, roll2, player);
            }
            else
            {
                player.UpdatePosition();
            }
            CurrentPlayer.NumberOfRolls++;
            do
            {
                Console.WriteLine(Board.Tiles[CurrentPlayer.CurrentPosition].GetType());
                Board.Tiles[CurrentPlayer.CurrentPosition].HandlePlayer(CurrentPlayer);
            } while (Board.Tiles[CurrentPlayer.CurrentPosition] is GooseTile);
            Console.WriteLine($"{CurrentPlayer.Name} on position {player.CurrentPosition} \n *********************");
        }

        private void HandleFirstThrow(int roll1, int roll2, Player player)
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

        private bool IsPlayerActive(Player player)
        {
            if (player.IsInWell)
            {
                return false;
            }
            if (player.Skips > 0)
            {
                player.Skips--;
                return false;
            }
            return true;
        }

        private void CreatePlayer(string name)
        {
            Players.Add(new Player(name, Board));
        }

        public void Restore()
        {
            throw new NotImplementedException();
        }
    }
}