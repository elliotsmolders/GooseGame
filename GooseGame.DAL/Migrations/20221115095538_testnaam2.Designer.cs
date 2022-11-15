﻿// <auto-generated />
using System;
using GooseGame.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GooseGame.DAL.Migrations
{
    [DbContext(typeof(GooseGameDbContext))]
    [Migration("20221115095538_testnaam2")]
    partial class testnaam2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GooseGame.DAL.Entities.GameBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("GameBoard");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.Tile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FieldNumber")
                        .HasColumnType("int");

                    b.Property<int?>("GameBoardId")
                        .HasColumnType("int");

                    b.Property<int>("TileType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.ToTable("Tile");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountOfThrows")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameBoardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentPosition")
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
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

            modelBuilder.Entity("GooseGame.DAL.Models.Player", b =>
                {
                    b.HasOne("GooseGame.DAL.Models.Game", null)
                        .WithMany("Players")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("GooseGame.DAL.Entities.GameBoard", b =>
                {
                    b.Navigation("Tiles");
                });

            modelBuilder.Entity("GooseGame.DAL.Models.Game", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}