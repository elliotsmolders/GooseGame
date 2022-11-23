using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public class PlayerEntity : BaseEntity, IEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int PlayerIcon { get; set; }

        [Required]
        public int NumberOfThrows { get; set; }

        public GameEntity Game { get; set; } = new GameEntity();
        public int GameId { get; set; }
        public bool GameWon { get; set; }
    }
}