using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiHangmanGames.Models;
using MauiHangmanGames.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiHangmanGames.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly GameService _gameService;
        public ObservableCollection<LeaderboardEntry> LeaderboardEntries { get; set; }
        public ICommand SelectModeCommand { get; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public HomeViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            _gameService = App.Services.GetService<GameService>();
#pragma warning restore CS8601 // Possible null reference assignment.
            LeaderboardEntries = new ObservableCollection<LeaderboardEntry>();
            SelectModeCommand = new Command<string>(OnSelectMode);
            LoadLeaderboardAsync();
        }

        private async void OnSelectMode(string GameMode)
        {
            GameMode mode;
            switch (GameMode)
            {
                case "Classique":
                    mode = new GameModeClassique();
                    break;
                case "Duel":
                    mode = new GameModeDuel();
                    break;
                case "Survie":
                    mode = new GameModeSurvie();
                    break;
                default:
                    return;
            }

            await Shell.Current.GoToAsync($"//PlayerLoginPage", new Dictionary<string, object>
            {
                { "GameMode", mode }
            });
        }

        private async void LoadLeaderboardAsync()
        {
            var entries = await _gameService.GetLeaderboardAsync();
            LeaderboardEntries.Clear();
            foreach (var entry in entries)
            {
                LeaderboardEntries.Add(entry);
            }
        }
    }
}
