using System.Collections.Generic;
using System.Linq;

namespace HangmanGames.Models
{
    public class Partie
    {
        public string MotADeviner { get; set; }
        public int EtatPendu { get; set; }
        public List<char> LettresDevinees { get; set; }
        public int NombreDeVies { get; set; } = 6;

        public Partie(string mot)
        {
            MotADeviner = mot;
            LettresDevinees = new List<char>();
        }

        public void DevinerLettre(char lettre)
        {
            if (!LettresDevinees.Contains(lettre))
            {
                LettresDevinees.Add(lettre);
                if (!MotADeviner.Contains(lettre))
                {
                    EtatPendu++;
                }
            }
        }

        public bool EstTermine()
        {
            return NombreDeVies == 0 || !MotADeviner.Except(LettresDevinees).Any();
        }
    }
}
