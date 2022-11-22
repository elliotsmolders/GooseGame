using GooseGame.DAL.Entities;
using GooseGame.DAL.Repositories;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.Business
{
    public class Service
    {
        private GameRepository _gameRepo;
        private PlayerRepository _playerRepo;
        private GamePlayerRepository _gamePlayerRepository;

        public Service()
        {
            _gameRepo = new GameRepository();
            _playerRepo = new PlayerRepository();
            _gamePlayerRepository = new GamePlayerRepository();
        }

        public void GetAllData()
        {
            //_gameRepo
            //_playerRepo
            _gamePlayerRepository._ctx.
        }
    }
}