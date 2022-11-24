using GooseGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GooseGame.DAL
{
    public class GooseGameDbContext : DbContext
    {
        public GooseGameDbContext()
        {
        }

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<GameEntity> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=ZENTOP;Database=GooseGameDB;Encrypt=False;Trusted_Connection=True;");
        }
    }
}