namespace GooseGame.Business.Tiles
{
    internal class MazeTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.CurrentPosition = 39;
        }
    }
}