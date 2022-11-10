namespace GooseGame.Business.Tiles
{
    internal class EndTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.CurrentPosition = 12;
            Console.WriteLine("End");
        }
    }
}