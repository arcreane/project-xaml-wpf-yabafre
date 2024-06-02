using MauiHangmanGames.Models;
using System;

namespace MauiHangmanGames.Services
{
    public class GestionnaireDePartie
    {
        public Game PartieCourante { get; private set; }

        public void InitialiserPartieClassique(Player player)
        {
            PartieCourante = new Game
            {
                GameMode = "Classique",
                NombreDeVies = 6,
                MotÀDeviner = GetMotAleatoire(),
                Player = player,
                DateAt = DateTime.Now
            };
        }

        public void InitialiserPartieDuel(Player player)
        {
            PartieCourante = new Game
            {
                GameMode = "Duel",
                NombreDeVies = 6,
                MotÀDeviner = GetMotAleatoire(),
                Player = player,
                DateAt = DateTime.Now
            };
        }

        public void InitialiserPartieSurvie(Player player)
        {
            PartieCourante = new Game
            {
                GameMode = "Survie",
                NombreDeVies = 1,
                MotÀDeviner = GetMotAleatoire(),
                Player = player,
                DateAt = DateTime.Now
            };
        }

        public bool VerifierLettre(char lettre)
        {
            if (PartieCourante == null)
                throw new InvalidOperationException("Aucune partie en cours.");

            if (PartieCourante.MotÀDeviner.Contains(lettre))
            {
                PartieCourante.LettresDevinees.Add(lettre);
                return true;
            }
            else
            {
                PartieCourante.NombreDeVies--;
                return false;
            }
        }

        public void TerminerPartie()
        {
            PartieCourante = null;
        }

        private string GetMotAleatoire()
        {
            // Implémentez la logique pour obtenir un mot aléatoire à partir de la base de données
            return "exemple"; // Exemple de mot, remplacez par la vraie logique
        }
    }
}
