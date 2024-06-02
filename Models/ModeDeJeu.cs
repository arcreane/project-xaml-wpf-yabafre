using MauiHangmanGames.Services;

namespace MauiHangmanGames.Models
{
    public abstract class ModeDeJeu
    {
        public abstract string Nom { get; }
        public abstract int ViesInitiales { get; }

        public abstract void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player);
    }

    public class ModeDeJeuClassique : ModeDeJeu
    {
        public override string Nom => "Classique";
        public override int ViesInitiales => 6;

        public override void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player)
        {
            gestionnaire.InitialiserPartieClassique(player);
        }
    }

    public class ModeDeJeuDuel : ModeDeJeu
    {
        public override string Nom => "Duel";
        public override int ViesInitiales => 6;

        public override void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player)
        {
            gestionnaire.InitialiserPartieDuel(player);
        }
    }

    public class ModeDeJeuSurvie : ModeDeJeu
    {
        public override string Nom => "Survie";
        public override int ViesInitiales => 1;

        public override void InitialiserPartie(GestionnaireDePartie gestionnaire, Player player)
        {
            gestionnaire.InitialiserPartieSurvie(player);
        }
    }
}
