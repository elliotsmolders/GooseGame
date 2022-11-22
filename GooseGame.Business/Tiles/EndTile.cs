using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class EndTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on positiion{player.CurrentPosition}");
        }
    }
}