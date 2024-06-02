namespace MauiHangmanGames.Models
{
    public class Attempt
    {
        public int AttemptId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public char Letter { get; set; }
        public bool IsGood { get; set; }
        public required Game Game { get; set; }
        public required Player Player { get; set; }
    }
}
