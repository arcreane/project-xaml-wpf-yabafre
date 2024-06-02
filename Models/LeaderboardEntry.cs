namespace MauiHangmanGames.Models
{
    public class LeaderboardEntry
    {
        public int LeaderboardEntryId { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime DateAchieved { get; set; }

        public Player Player { get; set; } = new Player();
    }
}
