namespace GooseGame.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}