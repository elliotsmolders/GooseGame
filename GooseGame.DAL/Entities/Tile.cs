using GooseGame.Entities;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class Tile : BaseEntity
    {
        [Range(1, 63)] // alle logica omvormen to be 1 based en spelers laten starten op 1 #Discuss
        public int FieldNumber { get; set; }

        public TileType TileType { get; set; }
    }
}