using System.ComponentModel.DataAnnotations;

namespace GooseGame.DAL.Entities
{
    public interface IEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}