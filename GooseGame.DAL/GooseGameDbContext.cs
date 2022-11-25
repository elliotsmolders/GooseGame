using GooseGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

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
            modelBuilder.Entity<PlayerEntity>()
                .HasOne(gp => gp.Game)
                .WithMany(g => g.Players)
                .HasForeignKey(gp => gp.GameId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=ZENTOP;Database=GooseGameDB;Encrypt=False;Trusted_Connection=True;");
        }
    }
}