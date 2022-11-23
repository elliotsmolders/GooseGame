﻿using GooseGame.Business;
using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
    public class GooseTile : Tile, ITile
    {
        public GooseTile(int tileId) : base(tileId)
        {

        }
        public void HandlePlayer(Player player)
        {
            Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on positiion{player.CurrentPosition} with roll {player.CurrentRoll}");
                        if (player.IsMovingBackwards)
            {
                player.CurrentRoll *= -1;
            }
            player.MovePlayer(player.CurrentRoll);
        }
    }
}