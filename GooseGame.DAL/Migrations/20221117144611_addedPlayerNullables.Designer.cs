﻿// <auto-generated />
using System;
using GooseGame.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GooseGame.DAL.Migrations
{
    [DbContext(typeof(GooseGameDbContext))]
    [Migration("20221117144611_addedPlayerNullables")]
    partial class addedPlayerNullables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("GooseGame.DAL.Entities.GameBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("GameBoard");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.PlayerGame", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("PlayerGame");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.Tile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FieldNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameBoardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TileType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.ToTable("Tile");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountOfThrows")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("End")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameBoardId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WinnerPlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId");

                    b.HasIndex("GameBoardId");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentPosition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IconPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Sequence")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.PlayerGame", b =>
                {
                    b.HasOne("GooseGame.DAL.Models.Game", "Game")
                        .WithMany("PlayerGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GooseGame.DAL.Models.Player", "Player")
                        .WithMany("PlayerGames")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.Tile", b =>
                {
                    b.HasOne("GooseGame.DAL.Entities.GameBoard", null)
                        .WithMany("Tiles")
                        .HasForeignKey("GameBoardId");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Game", b =>
                {
                    b.HasOne("GooseGame.DAL.Entities.GameBoard", "GameBoard")
                        .WithMany()
                        .HasForeignKey("GameBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GooseGame.DAL.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId");

                    b.Navigation("GameBoard");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.GameBoard", b =>
                {
                    b.Navigation("Tiles");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Game", b =>
                {
                    b.Navigation("PlayerGames");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Player", b =>
                {
                    b.Navigation("PlayerGames");
                });
#pragma warning restore 612, 618
        }
    }
}