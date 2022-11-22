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
    [Migration("20221119010612_Initial")]
    partial class Initial
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

            modelBuilder.Entity("GooseGame.DAL.Entities.GamePlayer", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Icon")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerPosition")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlayerSequence")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GamePlayer");
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

                    b.ToTable("Tiles");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Game", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<int?>("WinnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.GamePlayer", b =>
                {
                    b.HasOne("GooseGame.DAL.Models.Game", "Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GooseGame.DAL.Models.Player", "Player")
                        .WithMany("GamePlayers")
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
                        .HasForeignKey("WinnerId");

                    b.Navigation("GameBoard");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.GameBoard", b =>
                {
                    b.Navigation("Tiles");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Game", b =>
                {
                    b.Navigation("GamePlayers");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Player", b =>
                {
                    b.Navigation("GamePlayers");
                });
#pragma warning restore 612, 618
        }
    }
}