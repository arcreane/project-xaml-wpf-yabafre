using Microsoft.Maui.Controls;
using System;

namespace MauiHangmanGames.Views
{
    [QueryProperty(nameof(GameMode), "GameMode")]
    public partial class PlayerLoginPage : ContentPage
    {
        public string GameMode { get; set; } = string.Empty;

        public PlayerLoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Utiliser le GameMode pour configurer la page si nécessaire
        }

        private async void OnStartGameClicked(object sender, EventArgs e)
        {
            var playerName = PlayerNameEntry.Text;
            if (!string.IsNullOrEmpty(playerName))
            {
                await Shell.Current.GoToAsync($"///gamePage?PlayerName={playerName}&GameMode={GameMode}");
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez entrer un nom de joueur.", "OK");
            }
        }
    }
}
