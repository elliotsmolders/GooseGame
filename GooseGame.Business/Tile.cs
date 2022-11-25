using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business
{
    public class Tile : ITile
    {
        public Tile(int tileId)
        {
            TileId = tileId;
        }

        public string BackgroundImage { get; set; } = "pack://application:,,,/Resources/Icons/Default.png";
        public string Name { get; set; }
        public int TileId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        public virtual void HandlePlayer(Player player)
        {
            LogPlayerPosition(player);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="player"></param>
        private void LogPlayerPosition(Player player)
        {
            Logger.AddToCurrentTurnLog($"{player.Name} has landed on {Name} on position {TileId}");
        }
    }
}