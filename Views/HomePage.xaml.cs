using MauiHangmanGames.Models;
using MauiHangmanGames.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace MauiHangmanGames.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly LeaderboardService _leaderboardService;
        public ObservableCollection<LeaderboardEntry> LeaderboardEntries { get; set; } = new ObservableCollection<LeaderboardEntry>();

        public HomePage(LeaderboardService leaderboardService)
        {
            InitializeComponent();
            _leaderboardService = leaderboardService;
            LoadLeaderboard();
        }

        private async void LoadLeaderboard()
        {
            var leaderboardEntries = await _leaderboardService.GetTopScores();
            foreach (var entry in leaderboardEntries)
            {
                LeaderboardEntries.Add(entry);
            }
            LeaderboardListView.ItemsSource = LeaderboardEntries;
        }

        private async void OnModeClassiqueClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///playerLogin", true, new Dictionary<string, object>
            {
                { "GameMode", "Classique" }
            });
        }

        private async void OnModeDuelClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///playerLogin", true, new Dictionary<string, object>
            {
                { "GameMode", "Duel" }
            });
        }

        private async void OnModeSurvieClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///playerLogin", true, new Dictionary<string, object>
            {
                { "GameMode", "Survie" }
            });
        }
    }
}
