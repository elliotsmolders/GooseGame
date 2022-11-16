using GooseGame.Business;
using GooseGame.Business.Interfaces;

namespace GooseGame.Business.Tiles
{
    internal class GooseTile : ITile
    {
        public void HandlePlayer(Player player)
        {
            player.MovePlayer();
            //als em aant teruggaan is en em komt op een goose vakje dat em dan ook zo ver terug achteruit moet
            //boolean toevoegen van movebackwards voor goosetile om even ver achteruit te moeten gaan indien nodig
            //ma da moet ge dan efkes tot op het einde houden

            Console.WriteLine($"Goose by rolling {player.CurrentRoll}");
        }
    }
}