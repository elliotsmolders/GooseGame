using GooseGame.Entities;
using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class Tile : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 63)]
        public int FieldNumber { get; set; }

        public TileType TileType { get; set; }
    }
}