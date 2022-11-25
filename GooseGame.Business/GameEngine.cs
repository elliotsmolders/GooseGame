using GooseGame.Common;
using GooseGame.DAL;
using GooseGame.DAL.Entities;
using GooseGame.DAL.Repositories;
using System.Numerics;

namespace GooseGame.Business
{
    public class GameEngine
    {
        private readonly GameRepository _gameRepo;
        private readonly PlayerRepository _playerRepo;
        private readonly GooseGameDbContext _ctx;

        public GameEngine()
        {
            _ctx = new GooseGameDbContext();
            _playerRepo = new PlayerRepository();
            _gameRepo = new GameRepository();
        }

        public Player CurrentPlayer { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        public int TotalNumberOfRolls { get; set; }
        public Player Winner { get; set; } = null!;

        public int AmountOfPlayers { get; set; } = 4;
        public Dice DiceManager { get; set; } = new Dice();
        public static int Roll1 { get; set; }
        public static int Roll2 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Init()
        {
            CurrentPlayer = Players[0];
        }

        /// <summary>
        ///
        /// </summary>
        public void SetNextPlayer()
        {
            int index = Players.IndexOf(CurrentPlayer);
            CurrentPlayer = index >= Players.Count() - 1 ? Players[0] : Players[index + 1];
        }

        public int RollDice()
        {
            return DiceManager.RollDice();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roll1"></param>
        /// <param name="roll2"></param>
        public void PlayTurn(int roll1, int roll2)
        {
            int totalRoll = roll1 + roll2;
            Logger.ClearString();
            if (CurrentPlayer.IsPlayerActive(Players.Count))
            {
                if (totalRoll == 9 && CurrentPlayer.isOnStartTile())
                {
                    HandleFirstThrow(roll1, roll2);
                }
                else
                {
                    CurrentPlayer.MovePlayer(totalRoll);
                }

                CurrentPlayer.NumberOfRolls++;
                TotalNumberOfRolls++;
                //Console.WriteLine(CurrentPlayer.CurrentTile.GetType());
                CheckForWinner();
                Logger.AddToTotalLog();
                CurrentPlayer.IsMovingBackwards = false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void CheckForWinner()
        {
            if (CurrentPlayer.CurrentPosition == 63)
            {
                Winner = CurrentPlayer;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roll1"></param>
        /// <param name="roll2"></param>
        /// <exception cref="Exception"></exception>
        public void HandleFirstThrow(int roll1, int roll2)

        {
            if ((roll1 == 5 && roll2 == 4) || (roll1 == 4 && roll2 == 5))
            {
                CurrentPlayer.SetPlayerPosition(53);
            }
            else if ((roll1 == 6 && roll2 == 3) || (roll1 == 3 && roll2 == 6))
            {
                CurrentPlayer.SetPlayerPosition(26);
            }
            else
            {
                throw new Exception("unsupported dice variation that equals 9");
            }
        }

        public int SequenceTracker { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="icon"></param>
        public void CreatePlayer(string name, int icon)
        {
            Player player = new Player(name, icon)
            {
                Sequence = SequenceTracker
            };
            SequenceTracker++;
            Players.Add(player);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private async Task<PlayerEntity> AddPlayerAsync(GameEntity game, Player player)
        {
            PlayerEntity model = new PlayerEntity
            {
                Game = game,
                Name = player.Name,
                PlayerIcon = player.PlayerIcon,
                NumberOfThrows = player.NumberOfRolls,
                IsWinner = player.Name == CurrentPlayer.Name
            };

            await _playerRepo.AddAsync(model, _ctx);
            await _ctx.SaveChangesAsync();

            return model;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Player> GetPlayerAsync(int id)
        {
            PlayerEntity entity = await _playerRepo.GetAsync(id, _ctx);
            Player player = new Player(entity.Name)
            {
                PlayerIcon = entity.PlayerIcon
            };
            return player;
        }

        ///// <summary>
        /////
        ///// </summary>
        //private void GiveTempIdToPlayersInList()
        //{
        //    int i = 0;
        //    foreach (Player player in Players)
        //    {
        //        player.Id = i;
        //        i++;
        //    }
        //}

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        //public async Task WriteGameToDatabaseAsync()
        //{
        //    //GiveTempIdToPlayersInList();
        //    List<PlayerEntity> gamePlayers = await PlayerPrep();
        //    GameEntity game = await GamePrepAsync(gamePlayers);

        //    await _gameRepo.AddAsync(game);
        //}
        public async Task WriteGameToDatabaseAsync()
        {
            using (var scope = _ctx.Database.BeginTransaction())
            {
                //Save game
                GameEntity game = new()
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    ThrowsNeededToWin = TotalNumberOfRolls
                };
                await _ctx.AddAsync(game);
                await _ctx.SaveChangesAsync();

                //Save Players
                foreach (Player player in Players)
                {
                    var pe = await AddPlayerAsync(game, player);
                    game.Players.Add(pe);
                }

                scope.Commit();
            }
        }

        ///// <summary>
        /////
        ///// </summary>
        //public void GetHighScore()
        //{
        //}
    }
}