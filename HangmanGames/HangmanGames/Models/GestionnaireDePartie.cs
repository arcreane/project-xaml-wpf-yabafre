using System.Collections.Generic;
using System;

namespace HangmanGames
{
    public class GestionnaireDePartie
    {
        public List<string> ListeDesMots { get; set; }
        public Partie PartieCourante { get; set; }

        public GestionnaireDePartie()
        {
            ListeDesMots = new List<string> { /* ... */ };
        }

        public void CommencerNouvellePartie()
        {
            PartieCourante = new Partie
            {
                MotADeviner = S�lectionnerMot()
            };
        }

        public string S�lectionnerMot()
        {
            // S�lection al�atoire d'un mot
            var random = new Random();
            int index = random.Next(ListeDesMots.Count);
            return ListeDesMots[index];
        }
    }

}
