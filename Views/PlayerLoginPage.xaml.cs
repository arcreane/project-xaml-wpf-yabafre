using Microsoft.Maui.Controls;
using System;

namespace MauiHangmanGames.Views
{
    [QueryProperty(nameof(ModeDeJeu), "ModeDeJeu")]
    public partial class PlayerLoginPage : ContentPage
    {
        public string ModeDeJeu { get; set; } = string.Empty;

        public PlayerLoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Utiliser le ModeDeJeu pour configurer la page si nécessaire
        }

        private async void OnStartGameClicked(object sender, EventArgs e)
        {
            var playerName = PlayerNameEntry.Text;
            if (!string.IsNullOrEmpty(playerName))
            {
                await Shell.Current.GoToAsync($"///gamePage?PlayerName={playerName}&ModeDeJeu={ModeDeJeu}");
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez entrer un nom de joueur.", "OK");
            }
        }
    }
}
