namespace HangmanGames.Models
{
    public class Joueur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int ScoreActuel { get; set; }
        public int MeilleurScore { get; set; }

        public void MettreAjourScore(int points)
        {
            ScoreActuel += points;
        }

        public void ReinitialiserScore()
        {
            ScoreActuel = 0;
        }
    }
}
