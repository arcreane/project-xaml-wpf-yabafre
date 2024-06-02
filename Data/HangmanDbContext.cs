using Microsoft.EntityFrameworkCore;
using MauiHangmanGames.Models;
using Microsoft.Extensions.Logging;

namespace MauiHangmanGames.Data
{
    public class HangmanDbContext : DbContext
    {
        public HangmanDbContext()
        {
        }

        public HangmanDbContext(DbContextOptions<HangmanDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=hangmangame;Username=postgres;Password=leonepiecedelufy")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Word>().ToTable("words");
            modelBuilder.Entity<Player>().ToTable("players");
            modelBuilder.Entity<Game>().ToTable("games");
            modelBuilder.Entity<Attempt>().ToTable("attempts");
            modelBuilder.Entity<LeaderboardEntry>().ToTable("leaderboard_entries");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryId).HasColumnName("categoryid");
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.HasKey(e => e.WordId);
                entity.Property(e => e.WordId).HasColumnName("wordid");
                entity.Property(e => e.Text).HasColumnName("text");
                entity.Property(e => e.CategoryId).HasColumnName("categoryid");
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);
                entity.Property(e => e.PlayerId).HasColumnName("playerid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Level).HasColumnName("level");
                entity.Property(e => e.ScoreActuel).HasColumnName("scoreactuel");
                entity.Property(e => e.MeilleurScore).HasColumnName("meilleurscore");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);
                entity.Property(e => e.GameId).HasColumnName("gameid");
                entity.Property(e => e.MotÀDeviner).HasColumnName("motadeviner");
                entity.Property(e => e.ÉtatPendu).HasColumnName("etatpendu");
                entity.Property(e => e.NombreDeVies).HasColumnName("nombredevies");
                entity.Property(e => e.GameMode).HasColumnName("gamemode");
                entity.Property(e => e.DateAt).HasColumnName("dateat");
                entity.HasOne(e => e.Player)
                      .WithMany()
                      .HasForeignKey(e => e.PlayerId);
            });

            modelBuilder.Entity<Attempt>(entity =>
            {
                entity.HasKey(e => e.AttemptId);
                entity.Property(e => e.AttemptId).HasColumnName("attemptid");
                entity.Property(e => e.GameId).HasColumnName("gameid");
                entity.Property(e => e.PlayerId).HasColumnName("playerid");
                entity.Property(e => e.Letter).HasColumnName("letter");
                entity.Property(e => e.IsGood).HasColumnName("isgood");
                entity.HasOne(e => e.Game)
                      .WithMany()
                      .HasForeignKey(e => e.GameId);
                entity.HasOne(e => e.Player)
                      .WithMany()
                      .HasForeignKey(e => e.PlayerId);
            });

            modelBuilder.Entity<LeaderboardEntry>(entity =>
            {
                entity.HasKey(e => e.LeaderboardEntryId);
                entity.Property(e => e.LeaderboardEntryId).HasColumnName("leaderboardentryid");
                entity.Property(e => e.PlayerId).HasColumnName("playerid");
                entity.Property(e => e.PlayerName).HasColumnName("playername");
                entity.Property(e => e.Score).HasColumnName("score");
                entity.Property(e => e.DateAchieved).HasColumnName("dateachieved");
                entity.HasOne(le => le.Player)
                      .WithMany()
                      .HasForeignKey(le => le.PlayerId);
            });

            // Ajout de seeds pour les catégories et les mots
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Animaux" },
                new Category { CategoryId = 2, Name = "Pays" },
                new Category { CategoryId = 3, Name = "Science" }
            );

            modelBuilder.Entity<Word>().HasData(
                new Word { WordId = 1, Text = "Lion", CategoryId = 1 },
                new Word { WordId = 2, Text = "Tigre", CategoryId = 1 },
                new Word { WordId = 3, Text = "France", CategoryId = 2 },
                new Word { WordId = 4, Text = "Brésil", CategoryId = 2 },
                new Word { WordId = 5, Text = "Atome", CategoryId = 3 },
                new Word { WordId = 6, Text = "Molecule", CategoryId = 3 }
            );
        }
    }
}
