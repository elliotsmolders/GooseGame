using GooseGame.Entities;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class Tile : BaseEntity
    {
        [Range(0, 63)]
        public int FieldNumber { get; set; }

        public TileType TileType { get; set; }
    }
}