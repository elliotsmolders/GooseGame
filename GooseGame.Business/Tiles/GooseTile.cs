using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class GooseTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public GooseTile(int tileId) : base(tileId)
        {
            BackgroundImage = "pack://application:,,,/Resources/Icons/Goose.png";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public void HandlePlayer(Player player)
        {
            Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on position {player.CurrentPosition} with roll {player.CurrentRoll}");
            if (player.IsMovingBackwards)
            {
                player.CurrentRoll *= -1;
            }
            player.MovePlayer(player.CurrentRoll);
        }
    }
}