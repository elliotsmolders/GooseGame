namespace GooseGame.Business.Interfaces
{
    public interface ITile
    {


        public string Name { get; set; }

        public string BackgroundImage { get; set; }
        public void HandlePlayer(Player player);

    }
}