using GooseGame.DAL.Entities;
using GooseGame.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooseGame.DAL
{
    internal class GooseGameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerGame>().HasKey(pg => new { pg.PlayerId, pg.GameId });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-HCUMO6M\SQLEXPRESS;Database=GooseGameDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}