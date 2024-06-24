﻿// <auto-generated />
using System;
using System.Collections.Generic;
using MauiHangmanGames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MauiHangmanGames.Migrations
{
    [DbContext(typeof(HangmanDbContext))]
    partial class HangmanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MauiHangmanGames.Models.Attempt", b =>
                {
                    b.Property<int>("AttemptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("attemptid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AttemptId"));

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("gameid");

                    b.Property<bool>("IsGood")
                        .HasColumnType("boolean")
                        .HasColumnName("isgood");

                    b.Property<char>("Letter")
                        .HasColumnType("character(1)")
                        .HasColumnName("letter");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer")
                        .HasColumnName("playerid");

                    b.HasKey("AttemptId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("attempts", (string)null);
                });

            modelBuilder.Entity("MauiHangmanGames.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Animaux"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Pays"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("MauiHangmanGames.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("gameid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GameId"));

                    b.Property<DateTime>("DateAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dateat");

                    b.Property<string>("GameMode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gamemode");

                    b.Property<List<char>>("LettresDevinees")
                        .IsRequired()
                        .HasColumnType("character(1)[]");

                    b.Property<string>("MotÀDeviner")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("motadeviner");

                    b.Property<int>("NombreDeVies")
                        .HasColumnType("integer")
                        .HasColumnName("nombredevies");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("ÉtatPendu")
                        .HasColumnType("integer")
                        .HasColumnName("etatpendu");

                    b.HasKey("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("games", (string)null);
                });

            modelBuilder.Entity("MauiHangmanGames.Models.LeaderboardEntry", b =>
                {
                    b.Property<int>("LeaderboardEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("leaderboardentryid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LeaderboardEntryId"));

                    b.Property<DateTime>("DateAchieved")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dateachieved");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer")
                        .HasColumnName("playerid");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("playername");

                    b.Property<int>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score");

                    b.HasKey("LeaderboardEntryId");

                    b.HasIndex("PlayerId");

                    b.ToTable("leaderboard_entries", (string)null);
                });

            modelBuilder.Entity("MauiHangmanGames.Models.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("wordid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WordId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.HasKey("WordId");

                    b.HasIndex("CategoryId");

                    b.ToTable("words", (string)null);

                    b.HasData(
                        new
                        {
                            WordId = 1,
                            CategoryId = 1,
                            Text = "Lion"
                        },
                        new
                        {
                            WordId = 2,
                            CategoryId = 1,
                            Text = "Tigre"
                        },
                        new
                        {
                            WordId = 3,
                            CategoryId = 2,
                            Text = "France"
                        },
                        new
                        {
                            WordId = 4,
                            CategoryId = 2,
                            Text = "Brésil"
                        },
                        new
                        {
                            WordId = 5,
                            CategoryId = 3,
                            Text = "Atome"
                        },
                        new
                        {
                            WordId = 6,
                            CategoryId = 3,
                            Text = "Molecule"
                        });
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("playerid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("level");

                    b.Property<int>("MeilleurScore")
                        .HasColumnType("integer")
                        .HasColumnName("meilleurscore");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ScoreActuel")
                        .HasColumnType("integer")
                        .HasColumnName("scoreactuel");

                    b.HasKey("PlayerId");

                    b.ToTable("players", (string)null);
                });

            modelBuilder.Entity("MauiHangmanGames.Models.Attempt", b =>
                {
                    b.HasOne("MauiHangmanGames.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MauiHangmanGames.Models.Game", b =>
                {
                    b.HasOne("Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MauiHangmanGames.Models.LeaderboardEntry", b =>
                {
                    b.HasOne("Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MauiHangmanGames.Models.Word", b =>
                {
                    b.HasOne("MauiHangmanGames.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}