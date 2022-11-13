using GooseGame.Entities;
using Microsoft.EntityFrameworkCore;

namespace GooseGame.DAL.Entities
{
    public class GameBoard : BaseEntity
    {
        public virtual DbSet<Tile> Tiles { get; set; }
    }
}