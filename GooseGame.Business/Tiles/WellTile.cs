﻿using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class WellTile : ITile
    {
        public Player playerInWell { get; private set; }

        public void HandlePlayer(Player player)
        {

            if (playerInWell == null)
            {
                Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on positiion{player.CurrentPosition} there was no one in well");
                playerInWell = player;
            }
            else
            {
                Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on positiion{player.CurrentPosition} {playerInWell.Name} was in well and is freed");
                playerInWell.IsInWell = true;
                playerInWell = player;
            }
            player.IsInWell = false;

            Console.WriteLine("Well");
        }
    }
}