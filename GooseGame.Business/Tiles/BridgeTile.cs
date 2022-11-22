using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooseGame.Business.Interfaces;
using GooseGame.Common;

namespace GooseGame.Business.Tiles
{
   public class BridgeTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            Logger.AddToCurrentTurnLog($"{player.Name} has landed on {player.CurrentTile} on positiion{player.CurrentPosition}");
            player.SetPlayerPosition(12);
        }
    }
}