using GooseGame.Common;
using GooseGame.DAL.Entities;
using GooseGame.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GooseGame.Business
{
    public class GameEngine
    {
        private DateTime dateUpdated { get; set; } = DateTime.Now;
        private readonly GameRepository _gameRepo;
        private readonly PlayerRepository _playerRepo;

        public GameEngine()
        {
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

        public Tuple<int, int> RollDice()
        {
            Roll1 = DiceManager.RollDice();
            Roll2 = DiceManager.RollDice();
            return new Tuple<int, int>(Roll1, Roll2);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roll1"></param>
        /// <param name="roll2"></param>
        public void PlayTurn()
        {
            int totalRoll = Roll1 + Roll2;
            Logger.ClearString();
            if (CurrentPlayer.IsPlayerActive())
            {
                if (totalRoll == 9 && CurrentPlayer.isOnStartTile() && CurrentPlayer.NumberOfRolls < 2)
                {
                    HandleFirstThrow(Roll1, Roll2);
                }
                else
                {
                    CurrentPlayer.MovePlayer(totalRoll);
                }

                CurrentPlayer.NumberOfRolls++;
                TotalNumberOfRolls++;
                Console.WriteLine(CurrentPlayer.CurrentTile.GetType());
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
            Player player = new Player(name, icon);
            player.Sequence = SequenceTracker;
            SequenceTracker++;
            Players.Add(player);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public async Task AddPlayerAsync(Player player)
        {
            foreach (var item in Players)
            {
                PlayerEntity model = new PlayerEntity();
                model.Name = player.Name;
                model.PlayerIcon = player.PlayerIcon;
                model.NumberOfThrows = player.NumberOfRolls;
                if (player.CurrentPosition == 63)
                {
                    model.GameWon = true;
                }
                await _playerRepo.AddAsync(model);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Player> GetPlayerAsync(int id)
        {
            PlayerEntity entity = await _playerRepo.GetAsync(id);
            Player player = new Player(entity.Name);
            player.PlayerIcon = entity.PlayerIcon;
            return player;
        }

        /// <summary>
        ///
        /// </summary>
        private void GiveTempIdToPlayersInList()
        {
            int i = 0;
            foreach (Player player in Players)
            {
                player.Id = i;
                i++;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task WriteGameToDatabaseAsync()
        {
            GiveTempIdToPlayersInList();
            List<PlayerEntity> gamePlayers = await PlayerPrep();
            GameEntity game = await GamePrepAsync(gamePlayers);
            await _gameRepo.AddAsync(game);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="gamePlayers"></param>
        /// <returns></returns>
        private async Task<GameEntity> GamePrepAsync(List<PlayerEntity> gamePlayers)
        {
            GameEntity game = new GameEntity();
            game.Id = game.Id;
            game.DateUpdated = dateUpdated;
            game.Players = gamePlayers;
            game.DatePlayed = DateTime.Now;
            game.WinnerId = CurrentPlayer.Id;
            game.ThrowsNeededToWin = TotalNumberOfRolls;
            game.AmountOfPlayers = Players.Count;
            await UpdatePlayers(gamePlayers, game);
            return game;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="gamePlayers"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        private async Task UpdatePlayers(List<PlayerEntity> gamePlayers, GameEntity game)
        {
            foreach (PlayerEntity entity in gamePlayers)
            {
                entity.Game = game;
                entity.GameId = game.Id;

                if (entity.GameWon == null)
                {
                    entity.GameWon = false;
                }
                await _playerRepo.UpdateAsync(entity);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task<List<PlayerEntity>> PlayerPrep()
        {
            List<PlayerEntity> gamePlayers;
            foreach (Player player in Players)
            {
                await AddPlayerAsync(player);
            }
            return gamePlayers = _playerRepo._ctx.Players.OrderByDescending(p => p.Id).Take(Players.Count).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        public void GetHighScore()
        {
        }
    }
}