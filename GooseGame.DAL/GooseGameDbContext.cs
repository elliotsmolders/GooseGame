using GooseGame.DAL.Entities;
using GooseGame.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using System.Runtime.Serialization;

namespace GooseGame.DAL
{
    public class GooseGameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tile> Tiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePlayer>().HasKey(pg => new { pg.PlayerId, pg.GameId });

            modelBuilder.Entity<GamePlayer>()
                .HasOne(gp => gp.Game)
                .WithMany(g => g.GamePlayers)
                .HasForeignKey(gp => gp.GameId);

            modelBuilder.Entity<GamePlayer>()
                .HasOne(gp => gp.Player)
                .WithMany(g => g.GamePlayers)
                .HasForeignKey(gp => gp.PlayerId);

            modelBuilder.Entity<Tile>()
                .Property(c => c.TileType)
                .HasConversion<int>();

            modelBuilder.Entity<GamePlayer>()
                .Property(c => c.Icon)
                .HasConversion<int>();

            //var enumToString = new EnumToStringConverter<TileType>();
            //modelBuilder.Entity<Tile>(entity =>
            //{
            //    //entity.ToTable(nameof(FacultyMembers));
            //    //convert enums to string
            //    entity.Property(e => e.TileType).HasConversion(enumToString);
            //    //build check constraint from enum
            //    //var allowedEnumStrings = string.Join(',',
            //    //    typeof(Faculty).GetMembers()
            //    //        .Select(x => x.GetCustomAttribute(typeof(EnumMemberAttribute), false)).Where(x => x != null)
            //    //        .Select(x => $"'{((EnumMemberAttribute)x).Value}'"));
            //    //entity.HasCheckConstraint($"CK_{nameof(FacultyMembers)}_{nameof(Faculty.Description)}", $"{nameof(Faculty.Description)} in ({allowedEnumStrings})");
            //});

            //var enumToString2 = new EnumToStringConverter<Icon>();
            //modelBuilder.Entity<GamePlayer>(entity =>
            //{
            //    //entity.ToTable(nameof(FacultyMembers));
            //    //convert enums to string
            //    entity.Property(e => e.Icon).HasConversion(enumToString2);
            //    //build check constraint from enum
            //    //var allowedEnumStrings = string.Join(',',
            //    //    typeof(Faculty).GetMembers()
            //    //        .Select(x => x.GetCustomAttribute(typeof(EnumMemberAttribute), false)).Where(x => x != null)
            //    //        .Select(x => $"'{((EnumMemberAttribute)x).Value}'"));
            //    //entity.HasCheckConstraint($"CK_{nameof(FacultyMembers)}_{nameof(Faculty.Description)}", $"{nameof(Faculty.Description)} in ({allowedEnumStrings})");
            //});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data source = DB/GooseGame.db");
        }
    }
}