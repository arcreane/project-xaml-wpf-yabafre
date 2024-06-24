using MauiHangmanGames.Services;

namespace MauiHangmanGames.Models
{
    public abstract class GameMode
    {
        public abstract string Nom { get; }
        public abstract int ViesInitiales { get; }

        public abstract void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player);
    }

    public class GameModeClassique : GameMode
    {
        public override string Nom => "Classique";
        public override int ViesInitiales => 6;

        public override void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player)
        {
            gestionnaire.InitialiserPartieClassique(player);
        }
    }

    public class GameModeDuel : GameMode
    {
        public override string Nom => "Duel";
        public override int ViesInitiales => 6;

        public override void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player)
        {
            gestionnaire.InitialiserPartieDuel(player);
        }
    }

    public class GameModeSurvie : GameMode
    {
        public override string Nom => "Survie";
        public override int ViesInitiales => 1;

        public override void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player)
        {
            gestionnaire.InitialiserPartieSurvie(player);
        }
    }
}
