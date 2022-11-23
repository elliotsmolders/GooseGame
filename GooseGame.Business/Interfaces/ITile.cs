namespace GooseGame.Business.Interfaces
{
    public interface ITile
    {
        public string BackgroundImage { get; set; }
        public void HandlePlayer(Player player);
    }
}