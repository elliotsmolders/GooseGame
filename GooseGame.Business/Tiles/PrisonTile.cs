namespace GooseGame.Business.Tiles
{
    internal class PrisonTile : ITile
    {
        public void HandlePlayer() {
            Console.WriteLine("you are stuck in the prison :(");
        }
    }
}