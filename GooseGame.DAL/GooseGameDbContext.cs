using GooseGame.DAL.Entities;
using GooseGame.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GooseGame.DAL
{
    public class GooseGameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerGame>().HasKey(pg => new { pg.PlayerId, pg.GameId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data source = DB/GooseGame.db");
        }
    }
}