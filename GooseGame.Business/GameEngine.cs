using AutoMapper;
using GooseGame.Business.Models;
using GooseGame.Common;
using GooseGame.DAL.Entities;
using GooseGame.DAL.Repositories;

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
        private readonly GameRepository _gameRepo;
        private readonly PlayerRepository _playerRepo;
        //private readonly IMapper _playerMap;

        public GameEngine()
        {
            _playerRepo = new PlayerRepository();
            _gameRepo = new GameRepository();
            //var config = new MapperConfiguration
            //    (
            //        cfg =>
            //        {
            //            cfg.CreateMap<PlayerModel, PlayerEntity>()
            //            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            //            .ForMember(x => x.PlayerIcon, y => y.MapFrom(z => z.PlayerIcon))
            //            ;
            //        });
            //_playerMap = new Mapper(config);
        }

        public Player CurrentPlayer { get; set; }
        public List<Player> Players { get; set; } = new List<Player>(); // verhuisd naar Game instance

        public int TotalNumberOfRolls { get; set; }
        public Player Winner { get; set; } = null!;

        public int AmountOfPlayers { get; set; } = 4;
        public Dice DiceManager { get; set; } = new Dice(); // todo terug naar lijst idee
        public int Roll1 { get; set; }

        public void Init()
        {
            for (int i = 0; i < AmountOfPlayers; i++)
            {
                string name = $"Player {i}";
                CreatePlayer(name, i + 1);
            }
            CurrentPlayer = Players[0]; //nog logica achter steken voor speler met hoogste worp
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

        //player as parameter for playturn?
        public void PlayTurn(int roll1, int roll2)
        {
            Logger.ClearString();
            if (CurrentPlayer.IsPlayerActive())
            {
                int currentRoll = roll1 + roll2;
                //nu tweede if statement,possible refactor
                if (currentRoll == 9 && CurrentPlayer.isOnStartTile())
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

        public void HandleFirstThrow(int roll1, int roll2) // geld enkel op eerste worp of als speler op start staat? + terug implementeren, rename to throwfromstarttile or something?

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

        public void Restore()
        {
            throw new NotImplementedException();
        }

        public async Task AddPlayerAsync(string name, int playerIcon)
        {
            foreach (var item in Players)
            {
                Player player = new Player(name, playerIcon);
                PlayerEntity model = new PlayerEntity();
                model.Name = player.Name;
                model.PlayerIcon = player.PlayerIcon;
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

        public void WriteGameToDatabase()
        {
        }

        public void GetHighScore()
        {
        }
    }
}