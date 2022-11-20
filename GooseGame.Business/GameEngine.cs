using GooseGame.DAL.Entities;
using GooseGame.DAL.Models;
using GooseGame.DAL.Repositories;
using GooseGame.Entities;
using System.Collections.ObjectModel;

namespace GooseGame.Business
{
    public class GameEngine
    {
        private GameRepository _gameRepo = new GameRepository();
        private PlayerRepository _playerRepo = new PlayerRepository();
        private GamePlayerRepository _gamePlayerRepository = new GamePlayerRepository();

        public Player? CurrentPlayer { get; set; } // moet nog gezet worden
        public Game? Game { get; set; }
        public GamePlayer? GamePlayer { get; set; }
        public int CurrentPlayerPreviousPosition { get; set; }

        public List<Player?> Players { get; set; }

        public int TotalNumberOfRolls { get; set; }
        public Player Winner { get; set; } = null!;

        public Dice DiceManager { get; set; } = new Dice();

        public static int Roll1 { get; set; }
        public static int Roll2 { get; set; }
        public static int CurrentRoll => Roll1 + Roll2;

        /// <summary>
        /// Laad bestaande Spelers
        /// Laad bestaande Spellen
        /// </summary>
        public void Init()
        {
            foreach (GamePlayer gamePlayer in Game.GamePlayers)
            {
                Players.Add(gamePlayer.Player);
            }
        }

        public async Task LoadGameAsync(int index)
        {
            Game = await _gameRepo.GetAsync(index);
            CurrentPlayer = Players[GamePlayer.PlayerSequence];
        }

        public void NewGame()
        {
            CurrentPlayer = Players.First(); //nog logica achter steken voor speler met hoogste worp
        }

        public void BuildEntities()
        {
        }

        public void SetNextPlayer()
        {
            var product = (from p in _gamePlayerRepository._ctx
                .Include(p => p.ProductModel)
                           where p.ProductID == 814
                           select p).ToList();

            foreach (var p in product)
            {
                Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name);
            }
            if (CurrentPlayer.PlayerPosition == GameBoard.EndTilePosition)
            {
                Winner = CurrentPlayer;
            }
            else
            {
                int index = Players.IndexOf(CurrentPlayer);
                CurrentPlayer = index >= Players.Count - 1 ? Players.First() : Players[index + 1];
                //var findNextGamePlayer = _gameRepo._ctx.
                //GamePlayer = GamePlayer
            };
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

        private void HandleFirstThrow() // geldt enkel op eerste worp - zie specs
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

        public void Restore()
        {
            throw new NotImplementedException();
        }

        #region Data Related Tasks

        public async Task AddPlayerAsync(string playerName)
        {
            Player player = new Player();
            player.PlayerName = playerName;
            await _playerRepo.AddAsync(player);
        }

        public void InstantiatePlayers(ObservableCollection<Player> selectedPlayers)
        {
            Players = selectedPlayers.ToList();
        }

        public async Task InstantiateGameAsync()
        {
            Game = new Game();
            //await _gameRepo.AddAsync(Game); //unsure if needed
            //var LastAddedGame = await _gameRepo.GetAsync(Game.Id); //unsure if needed
            foreach (Player player in Players)
            {
                new GamePlayer()
                {
                    Player = player,
                    PlayerId = player.Id,
                    Game = Game,
                    GameId = Game.Id,
                    Icon = DAL.Icon.AmazonBox, // te fixen
                    TotalRolls = 0,
                    PlayerSequence = 0, //nog logica maken voor eerste speler en dan index van spelers oplopend
                    PlayerPosition = 0,
                    TurnsToSkip = 0
                };
            }
            await _gameRepo.AddAsync(Game);
        }

        public async Task<ObservableCollection<Player>> RetrievePlayers()
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Game>> RetrieveGames()
        {
            throw new NotImplementedException();
        }

        #endregion Data Related Tasks
    }
}