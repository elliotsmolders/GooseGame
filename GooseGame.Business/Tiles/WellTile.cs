﻿using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class WellTile : Tile, ITile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="tileId"></param>
        public WellTile(int tileId) : base(tileId)
        {
            BackgroundImage = "pack://application:,,,/Resources/Icons/Well.png";
        }

        public Player playerInWell { get; private set; }

        public void HandlePlayer(Player player)
        {
            //TODO refactor later
            if (playerInWell == null)
            {
                Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on position {player.CurrentPosition} there was no one in well");
                playerInWell = player;
            }
            else
            {
                Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on position {player.CurrentPosition} {playerInWell.Name} was in well and is freed");
                playerInWell.IsInWell = false;
                playerInWell = player;
            }
            player.IsInWell = true;
        }
    }
}