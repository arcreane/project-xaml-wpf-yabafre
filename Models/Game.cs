namespace MauiHangmanGames.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string MotÀDeviner { get; set; } = string.Empty;
        public int ÉtatPendu { get; set; }
        public List<char> LettresDevinees { get; set; } = new List<char>();
        public int NombreDeVies { get; set; }
        public int PlayerId { get; set; }
        public required Player Player { get; set; }
        public string GameMode { get; set; } = string.Empty;
        public DateTime DateAt { get; set; }

    }
}
