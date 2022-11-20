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
        public Player Winner { get; set; } = null!;

        public int AmountOfPlayers { get; set; } = 4;
        public Dice DiceManager { get; set; } = new Dice(); // todo terug naar lijst idee

        public static int Roll1 { get; set; }
        public static int Roll2 { get; set; }
        public static int CurrentRoll => Roll1 + Roll2;

        public void Init()
        {
            for (int i = 0; i < AmountOfPlayers; i++)
            {
                string name = $"Harold {i}";
                CreatePlayer(name);
            }
            CurrentPlayer = Players.First(); //nog logica achter steken voor speler met hoogste worp
        }

        public void SetNextPlayer()
        {
            if (CurrentPlayer.CurrentPosition == GameBoard.EndTilePosition) //naar aparte methode
            {
                Winner = CurrentPlayer;
            }
            else
            {
                int index = Players.IndexOf(CurrentPlayer);
                CurrentPlayer = index >= Players.Count - 1 ? Players.First() : Players[index + 1];
            }
        }

        public Tuple<int, int> RollDice()
        {
            Roll1 = DiceManager.RollDice();
            Roll2 = DiceManager.RollDice();
            return new Tuple<int, int>(Roll1, Roll2);
        }

        //player as parameter for playturn?
        public void PlayTurn()
        {
            if (CurrentPlayer.IsPlayerActive())
            {
                //nu tweede if statemment,possible refactor
                if (CurrentPlayer.NumberOfRolls == 0)
                {
                    HandleFirstThrow();
                }
                else
                {
                    CurrentPlayer.MovePlayer(CurrentRoll);
                    CurrentPlayer.NumberOfRolls++;
                }

                Console.WriteLine(CurrentPlayer.CurrentTile.GetType());
            }
        }

        private void HandleFirstThrow() // geldt enkel op eerste worp of als speler op start staat? + terug implementeren, rename to throwfromstarttile or something?
        {
            if ((Roll1 == 5 && Roll2 == 4) || (Roll1 == 4 && Roll2 == 5))
            {
                CurrentPlayer.SetPlayerPosition(53);
            }
            else if ((Roll1 == 6 && Roll2 == 3) || (Roll1 == 3 && Roll2 == 6))
            {
                CurrentPlayer.SetPlayerPosition(26);
            }
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