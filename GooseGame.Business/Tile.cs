﻿using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business
{
    public class Tile : ITile
    {
        public Tile(int tileId)
        {
            TileId = tileId;
        }

        public string BackgroundImage { get; set; } = "C:\\Users\\arnob\\source\\repos\\GooseGame\\GooseGameWPF\\Resources\\Icons\\Default.png";
        public string Name { get; set; }
        public int TileId { get; set; }
        public virtual void HandlePlayer(Player player)
        {
            LogPlayerPosition(player);
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
        public string GetTileName()
        {
            return this.Name;
        }



        public int GetTileId()
        {
            return this.TileId;
        }
        private void LogPlayerPosition(Player player)
        {
            Logger.AddToCurrentTurnLog($"{player.Name} has landed on {Name} on position {TileId}");
        }
    }
}