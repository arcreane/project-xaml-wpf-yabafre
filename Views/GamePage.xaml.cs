using Microsoft.Maui.Controls;
using MauiHangmanGames.Models;
using System;
using System.Collections.Generic;

namespace MauiHangmanGames.Views
{
    [QueryProperty(nameof(PlayerName), "PlayerName")]
    [QueryProperty(nameof(ModeDeJeu), "ModeDeJeu")]
    public partial class GamePage : ContentPage
    {
        public string PlayerName { get; set; } = string.Empty;
        public string ModeDeJeu { get; set; } = string.Empty;

        private string wordToGuess = string.Empty;
        private int lives;
        private HashSet<char> guessedLetters = new();

        public GamePage()
        {
            InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            // Initialiser les paramètres de jeu
            wordToGuess = GetRandomWord();
            lives = 6; // Exemple: 6 vies pour commencer
            guessedLetters = new HashSet<char>();

            UpdateWordDisplay();
            UpdateLivesDisplay();
            SetupKeyboard();
        }

        private string GetRandomWord()
        {
            // Logique pour obtenir un mot aléatoire à partir de la base de données
            // Pour l'exemple, on retourne un mot fixe
            return "EXEMPLE";
        }

        private void UpdateWordDisplay()
        {
            string display = "";
            foreach (var letter in wordToGuess)
            {
                if (guessedLetters.Contains(letter))
                {
                    display += letter + " ";
                }
                else
                {
                    display += "_ ";
                }
            }
            WordLabel.Text = display.Trim();
        }

        private void UpdateLivesDisplay()
        {
            LivesLabel.Text = $"Vies restantes : {lives}";
        }

        private void SetupKeyboard()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int columns = 7;
            int rows = (int)Math.Ceiling((double)alphabet.Length / columns);

            for (int i = 0; i < rows; i++)
            {
                KeyboardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            for (int j = 0; j < columns; j++)
            {
                KeyboardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                var button = new Button
                {
                    Text = alphabet[i].ToString(),
                    CommandParameter = alphabet[i]
                };
                button.Clicked += OnLetterButtonClicked;

                KeyboardGrid.Children.Add(button);
                Grid.SetColumn(button, i % columns);
                Grid.SetRow(button, i / columns);
            }
        }

        private void OnLetterButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is char letter)
            {
                button.IsEnabled = false;
                ProcessGuess(letter);
            }
        }

        private void ProcessGuess(char letter)
        {
            if (wordToGuess.Contains(letter))
            {
                guessedLetters.Add(letter);
                UpdateWordDisplay();

                if (!WordLabel.Text.Contains("_"))
                {
                    DisplayWinMessage();
                }
            }
            else
            {
                lives--;
                UpdateLivesDisplay();

                if (lives <= 0)
                {
                    DisplayLoseMessage();
                }
            }
        }

        private async void DisplayWinMessage()
        {
            await DisplayAlert("Gagné", "Félicitations, tu as deviné le mot !", "OK");
            // Logique pour terminer la partie ou rejouer
        }

        private async void DisplayLoseMessage()
        {
            await DisplayAlert("Perdu", "Désolé, tu as perdu. Le mot était " + wordToGuess, "OK");
            // Logique pour terminer la partie ou rejouer
        }
    }
}
