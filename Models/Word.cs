namespace MauiHangmanGames.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!; // Utiliser null-forgiving operator
    }
}
