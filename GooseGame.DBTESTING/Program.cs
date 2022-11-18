using GooseGame.DAL;
using GooseGame.DAL.Models;
using GooseGame.DAL.Repositories;
using GooseGame.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        BaseRepository<Player> _repo = new BaseRepository<Player>();

        Player player = new Player();
        player.Name = "Beire";

        void SaveNewPlayer(Player entity)
        {
            _repo.AddAsync(entity);
        }

        async Task RetrieveAsync()
        {
            foreach (Player player in await _repo.GetAllAsync())
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}