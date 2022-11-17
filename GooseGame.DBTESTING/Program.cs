using GooseGame.DAL;
using GooseGame.DAL.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        using GooseGameDbContext _ctx = new GooseGameDbContext();

        foreach (Player player in _ctx.Players)
        {
            Console.WriteLine(player.Name);
        }
    }
}