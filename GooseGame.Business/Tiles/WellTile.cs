namespace GooseGame.Business.Tiles
{
    internal class WellTile : ITile
    {
        public Player playerInWell { get; private set; }

        public void HandlePlayer(Player player)
        {
            if (playerInWell == null)
            {
                playerInWell = player;
            }
            else
            {
                playerInWell.IsActive = true;
                playerInWell = player;
            }
            player.IsActive = false;
        }
    }
}