using GooseGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GooseGame.DAL
{
    public class GooseGameDbContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<GameEntity> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data source = DB/GooseGame.db");
        }
    }
}