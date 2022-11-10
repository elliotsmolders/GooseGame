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
                playerInWell.IsInWell = true;
                playerInWell = player;
            }
            player.IsInWell = false;

            Console.WriteLine("Well");
        }
    }
}