using GooseGame.Business;
using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    public class GooseTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            if (player.IsMovingBackwards)
            {
                player.CurrentRoll *= -1;
            }
            player.MovePlayer(player.CurrentRoll);


            Console.WriteLine($"Goose by rolling {player.CurrentRoll}");
        }
    }
}