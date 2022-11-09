namespace GooseGame.Business.Tiles
{
    internal class MazeTile : ITile
    {
        public void HandlePlayer()
        {
            Console.WriteLine("you are stuck in the spooky maze");
        }
    }
}