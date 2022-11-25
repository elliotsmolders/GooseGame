using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GooseGame.DAL.Entities
{
    public class GameEntity : BaseEntity, IEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<PlayerEntity> Players { get; set; }

        [Required]
        public int ThrowsNeededToWin { get; set; }
    }
}