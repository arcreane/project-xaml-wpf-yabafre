public class Player
{
    public int PlayerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public int ScoreActuel { get; set; }
    public int MeilleurScore { get; set; } = 0;

    // Méthodes
    public void MettreÀJourScore(int points)
    {
        ScoreActuel += points;
        if (ScoreActuel > MeilleurScore)
        {
            MeilleurScore = ScoreActuel;
        }
    }

    public void RéinitialiserScore()
    {
        ScoreActuel = 0;
    }
}
