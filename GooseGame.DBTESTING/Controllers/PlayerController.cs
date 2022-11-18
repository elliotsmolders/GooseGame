using GooseGame.DAL.Models;
using GooseGame.Services;
using GooseGame.Services.Interfaces;

namespace GooseGame.DBTESTING.Controllers
{
    public class PlayerController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task CreateAsync(Player player)
        {
            await _playerService.AddAsync(player);
        }

        public void Read(Player player)
        {
        }

        public void ReadAll()
        {
        }

        public void Update(Player player)
        {
        }

        public void Delete(Player player)
        {
        }
    }
}