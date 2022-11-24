using GooseGame.Common;
using GooseGame.DAL.Entities;
using GooseGame.DAL.Repositories;

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
        public int Roll1 { get; set; }

        public void Init()
        {
            CurrentPlayer = Players[0];
        }

        public void SetNextPlayer()
        {
            int index = Players.IndexOf(CurrentPlayer);
            CurrentPlayer = index >= Players.Count() - 1 ? Players[0] : Players[index + 1];
        }

        public int RollDice()
        {
            return DiceManager.RollDice();
        }

        public void PlayTurn(int roll1, int roll2)
        {
            Logger.ClearString();
            if (CurrentPlayer.IsPlayerActive())
            {
                int currentRoll = roll1 + roll2;
                if (currentRoll == 9 && CurrentPlayer.isOnStartTile() && CurrentPlayer.NumberOfRolls < 2)
                {
                    HandleFirstThrow(roll1, roll2);
                }
                else
                {
                    CurrentPlayer.MovePlayer(currentRoll);
                }

                CurrentPlayer.NumberOfRolls++;
                TotalNumberOfRolls++;
                Console.WriteLine(CurrentPlayer.CurrentTile.GetType());
                CheckForWinner();
                Logger.AddToTotalLog();
                CurrentPlayer.IsMovingBackwards = false;
            }
        }

        public void CheckForWinner()
        {
            if (CurrentPlayer.CurrentPosition == 63)
            {
                Winner = CurrentPlayer;
            }
        }

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

        public void CreatePlayer(string name, int icon)
        {
            Players.Add(new Player(name, icon));
        }

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

        public async Task<Player> GetPlayerAsync(int id)
        {
            PlayerEntity entity = await _playerRepo.GetAsync(id);
            Player player = new Player(entity.Name);
            player.PlayerIcon = entity.PlayerIcon;
            return player;
        }

        private void GiveTempIdToPlayersInList()
        {
            int i = 0;
            foreach (Player player in Players)
            {
                player.Id = i;
                i++;
            }
        }

        public async Task WriteGameToDatabaseAsync()
        {
            GiveTempIdToPlayersInList();
            List<PlayerEntity> gamePlayers = await PlayerPrep();
            GameEntity game = await GamePrepAsync(gamePlayers);
            await _gameRepo.AddAsync(game);
        }

        private async Task<GameEntity> GamePrepAsync(List<PlayerEntity> gamePlayers)
        {
            GameEntity game = new GameEntity();
            game.DateUpdated = dateUpdated;
            game.Players = gamePlayers;
            game.DatePlayed = DateTime.Now;
            game.WinnerId = CurrentPlayer.Id;
            game.ThrowsNeededToWin = TotalNumberOfRolls;
            game.AmountOfPlayers = Players.Count;
            await UpdatePlayers(gamePlayers, game);
            return game;
        }

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

        private async Task<List<PlayerEntity>> PlayerPrep()
        {
            List<PlayerEntity> gamePlayers;
            foreach (Player player in Players)
            {
                await AddPlayerAsync(player);
            }
            return gamePlayers = (List<PlayerEntity>)(from p in _playerRepo._ctx.Players
                                                      orderby p.Id descending
                                                      select p).Take(Players.Count);
        }

        public void GetHighScore()
        {
        }
    }
}