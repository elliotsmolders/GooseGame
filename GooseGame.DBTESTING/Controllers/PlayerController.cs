using GooseGame.DAL.Models;
using GooseGame.Services;
using GooseGame.Services.Interfaces;

namespace GooseGame.DBTESTING.Controllers
{
    public class PlayerController
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void Create(Player player)
        {
            playerService.Insert(player);
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